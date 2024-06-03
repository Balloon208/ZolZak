using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Object
{
    public override void Interaction(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.coin += (int)value;

        UIManager.Instance.Setcointext();

        Destroy(gameObject);
    }
}