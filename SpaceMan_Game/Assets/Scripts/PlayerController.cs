using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables del movimiento del personaje
    public float jumpForce = 6f; //float
    private Rigidbody2D rb; //no colocar nada hace que la variable sea private

    
    void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }
}
