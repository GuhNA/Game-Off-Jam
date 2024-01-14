using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    //StaticVariables

    public int animGrow;
    float respawnTimerS_;

    Animator anim;

    public bool grow;
    float normalJump;

    public float respawnTimer;

    [Header("Jump Status")]
    public float grownJump, shrunkJump;

    [Header("height Status")]
    [Range(1,2)] public float growHeight;
    [Range(0,1)] public float shrinkHeight;
    Player player;

    #region encapsulamento
    public float respawnTimerS
    {
        get{return respawnTimerS_;}
        set{respawnTimerS_ = value;}
    }
    #endregion

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
    }
    
    private void Start() 
    {
        if(grow) anim.SetInteger("fds",animGrow);

        normalJump = player.jumpForce;  
        respawnTimerS = respawnTimer;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Drink();
        }
    }

    void Drink()
    {
        
        if(grow && (player.heightStatus == 1 || player.heightStatus == 3) && player.heightStatus != 2)
        {
            if(player.heightStatus == 1)
            {
                player.jumpForceS = grownJump;
                player.transform.localScale = Vector3.one * growHeight;
                player.heightStatus = 2;
                
            }
            else
            {
                player.jumpForceS = normalJump;
                player.transform.localScale = Vector3.one;
                player.heightStatus = 1;
            }
            
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if(!grow && (player.heightStatus == 1 || player.heightStatus == 2) && player.heightStatus != 3)
        {
            if(player.heightStatus == 1)
            {
                player.jumpForceS = shrunkJump;
                player.transform.localScale = Vector3.one * shrinkHeight;
                player.heightStatus = 3;
            }
            else
            {
                player.jumpForceS = normalJump;
                player.transform.localScale = Vector3.one;
                player.heightStatus = 1;
            }

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
