using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    Rigidbody2D rig_;

    #region encapsulamento
    public Rigidbody2D rig
    {
        get{return rig_;}
        set{rig_ = value;}
    }
    #endregion

    private void Awake() 
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        direction  = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.position += direction * speed * Time.deltaTime;
    }
}
