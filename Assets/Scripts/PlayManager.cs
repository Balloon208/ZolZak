using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameObject Hpbar;
    // Start is called before the first frame update
    void Start()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        RectTransform rectTransform = Hpbar.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(player.maxhp * 5, rectTransform.sizeDelta.y);
    }
}
