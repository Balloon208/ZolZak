using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public override void UseSkill()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Autodamage();
        Move();    
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.gameover==false)
        {
            GetScore();
        }
    }
}
