using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterInfo : MonoBehaviour
{
    public GameObject[] characters;
    public FishData fishdata;
    public Image fishimage;
    public Text fishname;
    public Text fishhp;
    public Text fishspeed;
    public Text skilldesciption;
    public Text buttontext;

    public void Start()
    {
        Setinfo();
    }

    public void Setinfo()
    {
        fishimage.sprite = fishdata.fishimage;
        fishname.text = fishdata.fishname;
        fishhp.text = fishdata.hp.ToString();
        fishspeed.text = fishdata.speed.ToString();
        skilldesciption.text = fishdata.skilldescription;
        SetButton();
    }

    public void SetButton()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            SetCharacterInfo characterInfo = characters[i].GetComponent<SetCharacterInfo>();
            if (User.fish[i] == false)
            {
                characterInfo.buttontext.text = characterInfo.fishdata.cost.ToString();
            }
            else if (User.equipedfish != i)
            {
                characterInfo.buttontext.text = "ÀåÂø";
            }
            else
            {
                characterInfo.buttontext.text = "»ç¿ëÁß";
            }
        }
    }
}
