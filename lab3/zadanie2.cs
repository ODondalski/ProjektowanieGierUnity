using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie2 : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 initialPosition;
    private bool flag = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (flag)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= initialPosition.x + 10.0f)
            {
                flag = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= initialPosition.x)
            {
                flag = true;
            }
        }
    }
}