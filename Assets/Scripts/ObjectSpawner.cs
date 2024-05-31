using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Object;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float min_delay;
    public float max_delay;
    Player player;
    private float delay;
    private bool summonlock;

    int summonline = 0;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        min_delay /= player.speed / 5;
        max_delay /= player.speed / 5;
    }

    void Summon()
    {
        bool defaultlock = false;

        int k = SetIndex();

        GameObject obstacle = obstacles[k];

        summonline = Random.Range(0, GameManager.Instance.lines.Length);
        if (obstacle.GetComponent<Object>().summonpos == Summonpos.Default)
        {
            defaultlock = true;
            int setpos = Random.Range(0, 2);
            if (setpos == 0) obstacle.GetComponent<Object>().summonpos = Summonpos.Left;
            if (setpos == 1) obstacle.GetComponent<Object>().summonpos = Summonpos.Right;
        }
        if (obstacle.GetComponent<Object>().summonpos == Summonpos.Left)
        {
            Instantiate(obstacle, new Vector2(GameManager.Instance.summonbars[0].transform.position.x, GameManager.Instance.lines[summonline].transform.position.y), Quaternion.identity);
        }
        if (obstacle.GetComponent<Object>().summonpos == Summonpos.Right)
        {
            Instantiate(obstacle, new Vector2(GameManager.Instance.summonbars[1].transform.position.x, GameManager.Instance.lines[summonline].transform.position.y), Quaternion.identity);
        }
        if (defaultlock == true)
        {
            obstacle.GetComponent<Object>().summonpos = Summonpos.Default;
            defaultlock = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay = Random.Range(min_delay, max_delay);
        if(summonlock == false)
        {
            Summon();
            min_delay /= 1.01f;
            max_delay /= 1.01f;
            summonlock = true;
            StartCoroutine(Wait(delay));
        }
    }

    int SetIndex()
    {
        int k = 0;

        for (int i = 0; i < obstacles.Length; i++)
        {
            k += obstacles[i].GetComponent<Obstacle>().chance;
        }
        k = Random.Range(0, k);

        int element = 0;
        int temp = obstacles[element].GetComponent<Obstacle>().chance;

        while (k > 0)
        {
            temp--;
            if (temp == 0)
            {
                element++;
                temp = obstacles[element].GetComponent<Obstacle>().chance;
            }
            k--;
        }
        return element;
    }

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        summonlock = false;
    }
}
