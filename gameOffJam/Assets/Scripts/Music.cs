using UnityEngine;

public class Music : MonoBehaviour
{
    

    // Update is called once per frame
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
