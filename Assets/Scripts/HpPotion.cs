using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : Object
{
    public override void Interaction(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.hp += value;
        if (player.hp > player.maxhp)
        {
            player.hp = player.maxhp;
        }

        UIManager.Instance.Sethpbar();

        Destroy(gameObject);
    }
}
