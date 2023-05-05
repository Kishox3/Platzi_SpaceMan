using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 6f;
    private Rigidbody2D rb; 
    public LayerMask groundMask;
    
    void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update() //Reconoce acciones por cada fotograma
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump() //Hace la accion de saltar
    {
        if (IsTouchingTheGround())
        {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }

    
    bool IsTouchingTheGround() //Indica si el personaje esta o no tocando el suelo
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask))
        {
            //TODO: programar logica de contacto
            return true;
        }
        else 
        {
            //TODO: programar logica de no contacto
            return false;
        }
    }
}
