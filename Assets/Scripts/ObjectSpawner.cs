using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : BaseSpawner
{
    [Serializable]
    public struct Items
    {
        public GameObject obj;
        public float delay;
    };
    public Items[] items;
    private float delay;

    protected override void Awake()
    {
        base.Awake();
        summonlock = new bool[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            items[i].delay /= player.speed/5;
            summonlock[i] = false;
        }

        for (int i = 0; i < items.Length; i++)
        {
            summonlock[i] = true;
            StartCoroutine(Wait(items[i].delay, i));
        }
    }

    protected override void Summon(int index)
    {
        SummonObject(items[index].obj);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (summonlock[i]==false)
            {
                summonlock[i] = true;
                Summon(i);
                StartCoroutine(Wait(items[i].delay, i));
            }
        }
    }

    IEnumerator Wait(float delay, int idx)
    {
        yield return new WaitForSeconds(delay);
        summonlock[idx] = false;
    }
}
