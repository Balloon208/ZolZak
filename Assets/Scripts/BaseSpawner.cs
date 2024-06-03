using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Object;

public abstract class BaseSpawner : MonoBehaviour
{
    protected int summonline = 0;
    protected bool[] summonlock;
    protected Player player;

    protected virtual void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    protected abstract void Summon(int index);

    protected void SummonObject(GameObject obj)
    {
        bool defaultlock = false;
        summonline = UnityEngine.Random.Range(0, GameManager.Instance.lines.Length);
        if (obj.GetComponent<Object>().summonpos == Summonpos.Default)
        {
            defaultlock = true;
            int setpos = UnityEngine.Random.Range(0, 2);
            if (setpos == 0) obj.GetComponent<Object>().summonpos = Summonpos.Left;
            if (setpos == 1) obj.GetComponent<Object>().summonpos = Summonpos.Right;
        }
        if (obj.GetComponent<Object>().summonpos == Summonpos.Left)
        {
            Instantiate(obj, new Vector2(GameManager.Instance.summonbars[0].transform.position.x, GameManager.Instance.lines[summonline].transform.position.y), Quaternion.identity);
        }
        if (obj.GetComponent<Object>().summonpos == Summonpos.Right)
        {
            Instantiate(obj, new Vector2(GameManager.Instance.summonbars[1].transform.position.x, GameManager.Instance.lines[summonline].transform.position.y), Quaternion.identity);
        }
        if (defaultlock == true)
        {
            obj.GetComponent<Object>().summonpos = Summonpos.Default;
            defaultlock = false;
        }
    }

    protected int SetIndex(GameObject[] obstacles)
    {
        int k = 0;

        for (int i = 0; i < obstacles.Length; i++)
        {
            k += obstacles[i].GetComponent<Object>().chance;
        }
        k = Random.Range(0, k);

        int element = 0;
        int temp = obstacles[element].GetComponent<Object>().chance;

        while (k > 0)
        {
            temp--;
            if (temp == 0)
            {
                element++;
                temp = obstacles[element].GetComponent<Object>().chance;
            }
            k--;
        }
        return element;
    }
}
