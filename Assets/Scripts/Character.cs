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
    public int diamond;
    public float score;
    public int line;
    public bool shield;

    [HideInInspector]
    public bool additionalhp;
    [HideInInspector]
    public bool additionalshield;
    [HideInInspector]
    public bool additionalspeed;
    protected bool autodamagelock;

    protected void Awake()
    {
        maxhp = CharacterSet.Instance.fishdata[User.equipedfish].hp;
        speed = CharacterSet.Instance.fishdata[User.equipedfish].speed;
        UseBoost();
        maxhp += (5*User.permamentupgrade[0]); // 물고기의 체력 + 체력 강화의 체력
        hp = maxhp;

        GetComponent<Animator>().runtimeAnimatorController = CharacterSet.Instance.fishdata[User.equipedfish].fishanimation;
        coin = 0;
        score = 0;
        line = 2;
    }

    public abstract void UseSkill();

    public void UseBoost()
    {
        if (User.additionalupgradeamount[0] > 0)
        {
            User.additionalupgradeamount[0]--;
            maxhp += 30;
        }
        if (User.additionalupgradeamount[1] > 0)
        {
            User.additionalupgradeamount[1]--;
            shield = true;
        }
        if (User.additionalupgradeamount[2] > 0)
        {
            User.additionalupgradeamount[2]--;
            speed *= 1.25f;
        }
    }

    public void Move()
    {
        if (GameManager.Instance.gameover) return;

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
        score += Mathf.Round(((speed * (1 + User.permamentupgrade[1]*0.1f)) /50)*10)/10f; // 추가로 userupgrade에 따른 speed 값도 필요
        score = Mathf.Round(score*10)/10f;
        UIManager.Instance.Setscoretext();
    }

    public IEnumerator Die()
    {
        ResultData.animcontroller = GetComponent<Animator>().runtimeAnimatorController;
        ResultData.score = score;
        ResultData.coin = coin;
        ResultData.diamond = diamond;

        yield return new WaitForSeconds(2f);
        GameObject.Find("GameManager").GetComponent<CustomSceneManager>().ChangeScene("GameOver");
    }

    public IEnumerator Autoattack(float delay)
    {
        yield return new WaitForSeconds(delay);
        hp -= 1;
        if (hp < 0)
        {
            hp = 0;
            GameManager.Instance.gameover = true;
            StartCoroutine(Die());
        }
        UIManager.Instance.Sethpbar();
        autodamagelock = false;
    }
}