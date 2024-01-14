using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGrow : MonoBehaviour
{
    float distance;
    public float grow;
    public float shrink;

    bool timeStop_;

    #region encapsulamento

    public bool timeStop
    {
        get{return timeStop_;}
        set{timeStop_ = value;}
    }

    #endregion

    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        distance = MathF.Abs(player.rig.position.x - transform.position.x);
        distance = Mathf.Clamp(distance, 1.5f, 4.5f);
        if(!timeStop)
        {
            if(player.rig.position.x < grow && player.rig.position.x > shrink)
            {
                transform.localScale = Vector3.one;
            }
            else if(distance > grow)
            {
                float change = distance - grow;
                transform.localScale = new Vector3(1 - change, 1 - change,1 - change);
            }
            else if(distance < shrink)
            {
                float change = shrink - distance;
                transform.localScale = new Vector3(1 + change,1 + change,1 + change);
            }
        }
    }
}
