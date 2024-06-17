using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public int selectid;
    Lobby_UIManager uimanager;

    public void Awake()
    {
        uimanager = GetComponent<Lobby_UIManager>();
    }
    // Start is called before the first frame update
    public void BuyItem()
    {
        int cost = 0;

        if (selectid < 3)
        {
            switch (selectid)
            {
                case 0:
                    cost = GameManager.Instance.upgradehpcost[User.permamentupgrade[selectid]];
                    break;
                case 1:
                    cost = GameManager.Instance.upgradespeedcost[User.permamentupgrade[selectid]];
                    break;
                case 2:
                    cost = GameManager.Instance.upgradeitemcost[User.permamentupgrade[selectid]];
                    break;
            }

            if (User.coin >= cost)
            {
                User.permamentupgrade[selectid]++;
                User.coin -= cost;
                GetComponent<Lobby_UIManager>().SetItemInfo(selectid);
            }
        }
        else if (selectid < 6)
        {
            cost = GameManager.Instance.additionalupgradecost[selectid - 3];

            if (User.coin >= cost)
            {
                User.additionalupgradeamount[selectid - 3]++;
                User.coin -= cost;
                GetComponent<Lobby_UIManager>().SetItemInfo(selectid);
            }
        }
        uimanager.SetCoin();
        uimanager.SetDiamond();
    }
}
