using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Slider hpbar;
    public Text scoretext;
    public Text cointext;

    public void Sethpbar()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        hpbar.value = player.hp / player.maxhp;
    }

    public void Setscoretext()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        scoretext.text = player.score.ToString() + "m";
    }

    public void Setcointext()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        cointext.text = player.coin.ToString();
    }
}
