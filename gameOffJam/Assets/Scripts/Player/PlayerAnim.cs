using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    Player player;

    private void Awake() {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        OnRun();
        OnJump();
    }


    void OnRun()
    {
        if(Mathf.Abs(player.rig.velocity.x) > 0.1f && player.onGrounded())
        {
            anim.SetInteger("select",1);
        }
        else 
        {
            anim.SetInteger("select",0);
        }
    }

    void OnJump()
    {
        if(player.rig.velocity.y > 0.2f && !player.onGrounded())
        {
            anim.SetTrigger("jump");
        }
        else if(player.rig.velocity.y < 0.2f && !player.onGrounded())
        {
            anim.SetTrigger("fall");
        }
    }


}
