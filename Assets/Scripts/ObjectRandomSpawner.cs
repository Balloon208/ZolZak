using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomSpawner : BaseSpawner
{
    public GameObject[] obstacles;
    public float min_delay;
    public float max_delay;
    private float delay;

    protected override void Awake()
    {
        base.Awake();
        min_delay /= player.speed / 5;
        max_delay /= player.speed / 5;
        summonlock = new bool[1];
    }

    protected override void Summon(int index)
    {
        index = SetIndex(obstacles);
        SummonObject(obstacles[index]);
    }

    // Update is called once per frame
    void Update()
    {
        delay = Random.Range(min_delay, max_delay);
        if (summonlock[0] == false)
        {
            Summon(0);
            min_delay /= 1.01f;
            max_delay /= 1.01f;
            summonlock[0] = true;
            StartCoroutine(Wait(delay));
        }
    }


    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        summonlock[0] = false;
    }
}
