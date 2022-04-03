using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.5f;
    Rigidbody2D corpo;
    Vector2 lastClickPos;
    bool moving;

    private void Awake()
    {
        corpo = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
            //Vector2 dire = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
           // transform.up = dire;
        }
        if(moving&& (Vector2)transform.position != lastClickPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
        }
        else
        {
            moving = false;
        }
    }
}
