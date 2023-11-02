using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGrow : MonoBehaviour
{
    float distance;
    public float distanceChange;
    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        distance = MathF.Abs(player.rig.position.x - transform.position.x);
        distance = Mathf.Clamp(distance, 0.5f, 5);
        float change = distance/2;
        if(distance > distanceChange)
        {

            
            transform.localScale = new Vector3(1+ change,1 + change,1 + change);
        }
        else if(distance < distanceChange)
        {
            transform.localScale = new Vector3(1 + change,1 + change,1 + change);
        }
    }
}
