using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float speed;
    public float autodamagetime;
    public int coin;
    public int score;
    public int line;

    protected bool autodamagelock;

    protected void Awake()
    {
        hp = maxhp;
        coin = 0;
        score = 0;
        line = 2;
    }

    public virtual void UseSkill()
    {

    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && line > 0)
        {
            line--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && line < 4)
        {
            line++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, GameManager.Instance.lines[line].transform.position.y, 0), Time.deltaTime * 10);
    }

    public void Autodamage()
    {
        if(autodamagelock == false)
        {
            autodamagelock = true;
            StartCoroutine(Autoattack(autodamagetime));
        }
    }

    public IEnumerator Autoattack(float delay)
    {
        yield return new WaitForSeconds(delay);
        hp -= 1;
        UIManager.Instance.Sethpbar();
        autodamagelock = false;
    }
}