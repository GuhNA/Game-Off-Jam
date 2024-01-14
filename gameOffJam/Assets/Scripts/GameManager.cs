using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GrowShrink> potions = new();
    private void Awake() 
    {
        foreach(GrowShrink i in FindObjectsOfType<GrowShrink>())
        {
            potions.Add(i);
        }

    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        foreach(GrowShrink i in potions)
        {
            if(!i.GetComponent<SpriteRenderer>().enabled)
            {
                i.respawnTimer -= Time.deltaTime;
                if(i.respawnTimer <= 0)
                {
                    i.GetComponent<SpriteRenderer>().enabled = true;
                    i.GetComponent<BoxCollider2D>().enabled = true;
                    i.respawnTimer = i.respawnTimerS;
                }
            }
        }
    }
}
