using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] lines;
    public GameObject[] LRbars;
    public GameObject[] summonbars;
    public GameObject[] deletebars;
    public bool gameover;

    public int[] upgradehpcost =
    {
        1000,
        2000,
        3000,
        4000,
        5000,
        6000,
        7000,
        8000,
        9000,
        10000,
        12000,
        14000,
        16000,
        18000,
        20000,
        22000,
        24000,
        26000,
        28000
    };

    public int[] upgradespeedcost =
    {
        1000,
        2000,
        3000,
        4000,
        5000,
        6000,
        7000,
        8000,
        9000,
        10000,
        12000,
        14000,
        16000,
        18000,
        20000,
        22000,
        24000,
        26000,
        28000
    };

    public int[] upgradeitemcost =
    {
        1000,
        2000,
        3000,
        4000,
        5000,
        6000,
        7000,
        8000,
        9000,
        10000,
        12000,
        14000,
        16000,
        18000,
        20000,
        22000,
        24000,
        26000,
        28000
    };

    public int[] additionalupgradecost = { 500, 700, 1000 };
}
