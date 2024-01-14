using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakuraStatus : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    Zawarudo zar;
    public Sprite ini;
    public Sprite grown;

    Animator anim;

    public bool isGrown;
    public bool beforeStatus;

    private void Awake() 
    {
        zar = FindObjectOfType<Zawarudo>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    private void Start()
    {
        beforeStatus = isGrown;
    }
    
    private void Update()
    {
        if(zar.time != 5000) isGrown = true;
        else isGrown = false;

        if(isGrown !=  beforeStatus)
        {
            if(isGrown) 
            {
                anim.SetTrigger("grow");
            }
            else
            {
                anim.SetTrigger("Shrink");

            }
            beforeStatus = isGrown;
        }

    }

    public void Grown()
    {
        anim.SetBool("isGrown", true);
    }

     public void Shrink()
    {
        anim.SetBool("isGrown", false);
    }

}
