using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum Summonpos
    {
        Left, Right
    };

    public Summonpos summonpos;
    public float damage;
    public float speed;
    public bool move;
    public bool back;
    public float min_delay;
    public float max_delay;

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
