using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : items
{
    //Static variables
    float iniTime;

    public float time;
    
    
    public ItemsGrow changeSize;

    private void Start()
    {
        iniTime = time;
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q)) changeSize.timeStop = true;
        if(changeSize.timeStop == true)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                changeSize.timeStop = false;
                time = iniTime;
            }
        }
    }
}
