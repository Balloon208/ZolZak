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

    string[] itemnamelist = {"ü�°�ȭ", "�ӵ���ȭ", "�����۰�ȭ", "�߰�ü��", "�߰���ȣ��", "�߰��ӵ�"};
    string[] itemdescriptionlist =
    {
        "������� ü���� �����Ͽ� �� ���� ������ �� �ֽ��ϴ�.",
        "������� �ӵ��� �����Ͽ� �� ������ ������ �� �ֽ��ϴ�. ��ֹ� �� �������� ����ð��� ������ ��ġ�� �ʽ��ϴ�.",
        "�������� �����ϴ� �ӵ��� �� �������ϴ�.",
        "�߰� ü���� ���� ���·� ������ �����մϴ�. ���� �Ҹ�˴ϴ�.",
        "�浹�� 1ȸ ������ִ� ��ȣ���� ���� ���·� ������ �����մϴ�. ���� �Ҹ�˴ϴ�.",
        "�ӵ��� �߰��� �����Ͽ� ���� ������ ������ �� �ֽ��ϴ�. ��ֹ� �� �������� ����ð��� ������ ��Ĩ�ϴ�. ���� �Ҹ�˴ϴ�."
    };

    public void SetItemInfo(int itemid)
    {
        GetComponent<LobbyManager>().selectid = itemid;

        if (itemid < 3)
        {
            itemname.text = itemnamelist[itemid] + " Lv." + User.permamentupgrade[itemid].ToString();
            cost.text = GameManager.Instance.upgradehpcost[User.permamentupgrade[itemid]].ToString();
            buttontext.text = "���׷��̵�";
        }
        else if (itemid < 6)
        {
            itemname.text = itemnamelist[itemid] + " x" + User.additionalupgradeamount[itemid - 3].ToString();
            cost.text = GameManager.Instance.additionalupgradecost[itemid - 3].ToString();
            buttontext.text = "����";
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