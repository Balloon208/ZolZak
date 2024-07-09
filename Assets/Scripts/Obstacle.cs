using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Object
{
    public override void Interaction(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player.shield == true)
        {
            player.UseShield();
            return;
        }

        player.hp -= value;
        if (player.hp < 0)
        {
            player.hp = 0;
            GameManager.Instance.gameover = true;
            StartCoroutine(player.Die());
        }

        UIManager.Instance.Sethpbar();

        Destroy(gameObject);
    }
}