using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    int summonline = 0;
    void Start()
    {
        summonline = Random.Range(0, GameManager.Instance.lines.Length);
        if(obstacle.GetComponent<Obstacle>().summonpos == Obstacle.Summonpos.Left)
        {
            Instantiate(obstacle, new Vector2(GameManager.Instance.summonbars[0].transform.position.x, GameManager.Instance.lines[summonline].transform.position.y), Quaternion.identity);
        }
        if (obstacle.GetComponent<Obstacle>().summonpos == Obstacle.Summonpos.Right)
        {
            Instantiate(obstacle, new Vector2(GameManager.Instance.summonbars[1].transform.position.x, GameManager.Instance.lines[summonline].transform.position.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}