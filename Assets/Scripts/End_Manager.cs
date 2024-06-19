using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Manager : MonoBehaviour
{
    public Text scoretext;
    public Image fishimage;
    public Text cointext;
    public Text diamondtext;

    private void Awake()
    {
        fishimage.sprite = ResultData.charactersprite;
        scoretext.text = ResultData.score.ToString();
        cointext.text = ResultData.coin.ToString();
        diamondtext.text = ResultData.diamond.ToString();

        GameManager.Instance.gameover = false;
        User.distance += ResultData.score;
        User.coin += ResultData.coin;
        User.diamond += ResultData.diamond;
    }
}
