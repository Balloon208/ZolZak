using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Lobby_UIManager : MonoBehaviour
{
    public Slider distance;
    public Text distancetext;
    public Text coin;
    public Text diamond;
    public Text itemname;
    public Image itemimage;
    public Text cost;
    public Text itemdescription;
    public Text buttontext;

    private void Awake()
    {
        SetItemInfo(0);
        SetCoin();
        SetDistance();
        SetDiamond();
    }

    string[] itemnamelist = {"체력강화", "속도강화", "아이템강화", "추가체력", "추가보호막", "추가속도"};
    string[] itemdescriptionlist =
    {
        "물고기의 체력이 증가하여 더 오래 수영할 수 있습니다.",
        "물고기의 속도가 증가하여 더 빠르게 수영할 수 있습니다. 장애물 및 아이템의 등장시간에 영향을 끼치지 않습니다.",
        "아이템이 등장하는 속도가 더 빨라집니다.",
        "추가 체력을 가진 상태로 게임을 시작합니다. 사용시 소모됩니다.",
        "충돌을 1회 방어해주는 보호막을 가진 상태로 게임을 시작합니다. 사용시 소모됩니다.",
        "속도가 추가로 증가하여 더욱 빠르게 수영할 수 있습니다. 장애물 및 아이템의 등장시간에 영향을 끼칩니다. 사용시 소모됩니다."
    };

    public void SetItemInfo(int itemid)
    {
        GetComponent<LobbyManager>().selectid = itemid;

        if (itemid < 3)
        {
            itemname.text = itemnamelist[itemid] + " Lv." + User.permamentupgrade[itemid].ToString();
            cost.text = GameManager.Instance.upgradehpcost[User.permamentupgrade[itemid]].ToString();
            buttontext.text = "업그레이드";
        }
        else if (itemid < 6)
        {
            itemname.text = itemnamelist[itemid] + " x" + User.additionalupgradeamount[itemid - 3].ToString();
            cost.text = GameManager.Instance.additionalupgradecost[itemid - 3].ToString();
            buttontext.text = "구매";
        }
        itemdescription.text = itemdescriptionlist[itemid];

        GameObject temp = EventSystem.current.currentSelectedGameObject;

        if (temp != null)
        {
            Image setimage = temp.transform.GetChild(0).GetComponent<Image>();
            if (setimage != null)
            {
                itemimage.sprite = setimage.sprite;
                itemimage.color = setimage.color;
            }
        }
    }

    public void SetDistance()
    {
        distance.value = User.distance / 300000f;
        float temp = Mathf.Round(User.distance / 1000 * 100) / 100f;

        Debug.Log(temp);
        distancetext.text = temp.ToString() + "km";
    }

    public void SetCoin()
    {
        coin.text = User.coin.ToString();
    }

    public void SetDiamond()
    {
        diamond.text = User.diamond.ToString();
    }

    public void TurnOnCanvas(GameObject onCanvas)
    {
        if (onCanvas != null)
        {
            onCanvas.SetActive(true);
        }
    }

    public void TurnOffCanvas(GameObject offCanvas)
    {
        if (offCanvas != null)
        {
            offCanvas.SetActive(false);
        }
    }

}