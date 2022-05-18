using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float resetX;
    public float speed = 10;
    private Vector3 startPos;
    private Vector2 direction;

    public static BGScrolling instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        direction = new Vector2(1, 1);
    }

    

    public void Scrolling ()
    {
        if (transform.position.x>=resetX)
        {
            transform.Translate(-direction * speed * Time.deltaTime);
        }
        else
        {
            transform.position = startPos;
        }
    }

    public void resetPos ()
    {
        transform.position = startPos;
    }
        
}
