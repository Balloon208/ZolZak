using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{
    public enum Summonpos
    {
        Default, Left, Right
    };

    public Summonpos summonpos;
    public float value;
    public float speed;
    public bool move;
    public bool back;
    public float min_delay;
    public float max_delay;
    public int chance;

    Rigidbody2D rigid;
    Player player;
    [SerializeField]
    private bool backlock;
    [SerializeField]
    private bool movelock;
    private float ypos;

    private int targetline;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ypos = transform.position.y;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        speed *= player.speed / 5;
        min_delay /= player.speed / 5;
        max_delay /= player.speed / 5;
    }

    public abstract void Interaction(Collider2D collision);

    // Update is called once per frame
    protected void Update()
    {
        if (summonpos == Summonpos.Left) targetline = 1;
        if (summonpos == Summonpos.Right) targetline = 0;

        if (move == true && movelock == false)
        {
            movelock = true;
            float delay = Random.Range(min_delay, max_delay);
            StartCoroutine(Timer(delay));
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, ypos), Time.deltaTime * 30);

        if (back == true)
        {
            rigid.velocity = new Vector2(GameManager.Instance.summonbars[targetline].transform.position.x - transform.position.x, rigid.velocity.y);

            if (Mathf.Abs(rigid.velocity.x) > speed)
            {
                if (summonpos == Summonpos.Left)
                {
                    rigid.velocity = new Vector2(speed, rigid.velocity.y);
                }
                if (summonpos == Summonpos.Right)
                {
                    rigid.velocity = new Vector2(-speed, rigid.velocity.y);
                }
            }

            if (backlock == true)
            {
                rigid.velocity = new Vector2(-rigid.velocity.x, rigid.velocity.y);
            }
            if (((rigid.velocity.x < 3f && summonpos == Summonpos.Left) || (rigid.velocity.x > -3f && summonpos == Summonpos.Right)) && backlock == false)
            {
                movelock = false;
                backlock = true;
            }
        }
        else
        {
            if (summonpos == Summonpos.Left)
            {
                rigid.velocity = new Vector2(speed, rigid.velocity.y);
            }
            if (summonpos == Summonpos.Right)
            {
                rigid.velocity = new Vector2(-speed, rigid.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeleteLine") == true)
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") == true)
        {
            Interaction(collision);
        }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        int moveline = Random.Range(0, GameManager.Instance.lines.Length);
        ypos = GameManager.Instance.lines[moveline].transform.position.y;
    }
}
