using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player
{
    // Update is called once per frame
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && line > 0)
        {
            line--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && line < 4)
        {
            line++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, GameManager.Instance.lines[line].transform.position.y, 0), Time.deltaTime*10);
    }
}
