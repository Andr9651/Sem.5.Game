using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pico : MonoBehaviour
{
    public List<Sensor> Sensors;

    // Start is called before the first frame update
    public Sensor Left;
    public Sensor Right;

    public int leftLast;
    public int rightLast;

    public bool leftTrigger;
    public bool rightTrigger;

    public int count;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLeft(Left.value);
        UpdateRight(Right.value);
    }

    public void UpdateLeft(int value)
    {
        if (leftLast == -value)
        {
            leftLast = value;


            leftTrigger = !leftTrigger;

            if (rightTrigger && leftTrigger)
            {
                count--;
                rightTrigger = false;
                leftTrigger = false;
            }
        }
    }

    public void UpdateRight(int value)
    {
        if (rightLast == -value)
        {
            rightLast = value;


            rightTrigger = !rightTrigger;

            if (rightTrigger && leftTrigger)
            {
                count++;
                rightTrigger = false;
                leftTrigger = false;
            }
        }
    }
}