using UnityEngine;

public class size : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(GetComponent<SpriteRenderer>().bounds.max);
    }

}