using UnityEngine;

public class fallReset : MonoBehaviour
{
    public Transform resetPos; 

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.CompareTag("Player")) other.transform.position = resetPos.position;
    }
}
