using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float scrollamount;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -scrollamount)
        {
            transform.position = target.position - Vector3.left * scrollamount;
        }
    }
}
