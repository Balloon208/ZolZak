using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Lobby_UIManager : MonoBehaviour
{
    public Text itemname;
    public Image itemimage;
    public Text coin;
    public Text itemdescription;
    public Text buttontext;

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
        if (itemid < 3)
        {
            itemname.text = itemnamelist[itemid] + " Lv." + User.permamentupgrade[itemid].ToString();
            switch (itemid)
            {
                case 0:
                    coin.text = GameManager.Instance.upgradehpcost[User.permamentupgrade[0]].ToString();
                    break;
                case 1:
                    coin.text = GameManager.Instance.upgradespeedcost[User.permamentupgrade[1]].ToString();
                    break;
                case 2:
                    coin.text = GameManager.Instance.upgradeitemcost[User.permamentupgrade[2]].ToString();
                    break;
            }

            buttontext.text = "���׷��̵�";
        }
        else if (itemid < 6)
        {
            itemname.text = itemnamelist[itemid] + " x" + User.additionalupgradeamount[itemid - 3].ToString();
            buttontext.text = "����";
        }
        itemdescription.text = itemdescriptionlist[itemid];
        Image setimage = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>();
        itemimage.sprite = setimage.sprite;
        itemimage.color = setimage.color;
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