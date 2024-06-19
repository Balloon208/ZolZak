using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSet : Singleton<CharacterSet>
{
    public FishData[] fishdata;
    public Image characterimage;
    SetCharacterInfo characterinfo;

    public void Buyfish()
    {
        FishData fish = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<SetCharacterInfo>().fishdata;
        if (User.fish[fish.id] == true || User.coin < fish.cost) return;
        User.coin -= fish.cost;
        User.fish[fish.id] = true;
    }

    public void Setfish()
    {
        characterinfo = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<SetCharacterInfo>();
        FishData fish = characterinfo.fishdata;
        if (User.fish[fish.id] == false) return;
        User.equipedfish = fish.id;
        characterimage.sprite = fishdata[fish.id].fishimage;
        characterinfo.Setinfo();
        characterinfo.SetButton();

        Debug.Log(User.equipedfish);
    }
}
