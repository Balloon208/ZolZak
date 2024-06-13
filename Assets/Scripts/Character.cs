using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float speed;
    public float autodamagetime;
    public int coin;
    public float score;
    public int line;

    protected bool autodamagelock;

    protected void Awake()
    {
        hp = maxhp;
        coin = 0;
        score = 0;
        line = 2;
    }

    public abstract void UseSkill();

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

    public void GetScore()
    {
        score += Mathf.Round((speed/50)*10)/10f; // 추가로 userupgrade에 따른 speed 값도 필요
        score = Mathf.Round(score*10)/10f;
        UIManager.Instance.Setscoretext();
    }

    public IEnumerator Autoattack(float delay)
    {
        yield return new WaitForSeconds(delay);
        hp -= 1;
        if (hp < 0)
        {
            hp = 0;
            GameManager.Instance.gameover = true;
        }
        UIManager.Instance.Sethpbar();
        autodamagelock = false;
    }
}