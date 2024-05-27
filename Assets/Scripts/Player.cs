using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float speed;
    public int coin;
    public int score;
    public int line;

    protected void Awake()
    {
        hp = maxhp;
        coin = 0;
        score = 0;
        line = 2;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
