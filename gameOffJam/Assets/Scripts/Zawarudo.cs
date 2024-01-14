using UnityEngine;

public class Zawarudo : MonoBehaviour
{
    float iniTime;

    public float time;
    
    
    public ItemsGrow changeSize;

    private void Start()
    {
        iniTime = time;
    }

    private void Update() 
    {
        if(changeSize.timeStop == true)
        {
            time -= Time.deltaTime * 1000;
            if(time <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                changeSize.timeStop = false;
                time = iniTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        changeSize.timeStop = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
