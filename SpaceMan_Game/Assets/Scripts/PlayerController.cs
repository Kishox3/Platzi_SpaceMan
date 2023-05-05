using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* -- variables -- */

    //public
    public float jumpForce = 6f;
    public LayerMask groundMask;
    //private
    private Rigidbody2D rb; 
    private Animator animator;
    //constant
    private const string STATE_ALIVE = "isAlive";                   
    private const string STATE_ON_THE_GROUND = "isOnTheGround";     


    /* -- core methods -- */

    //inicializa cuando se abre el juego
    void Start(){
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    }

    //inicializa cuando se activa el script
    void Awake()
    {
   
        rb = GetComponent<Rigidbody2D>();           //se obtiene componente del rigidbody del personaje
        animator = GetComponent<Animator>();        //se obtiene componente del animator del personaje
    }

    //Reconoce acciones por cada fotograma
    void Update() { 
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());               //se le da un valor a una variable desde lo que devuleve el metodo

        // -- gizmos  --
        Debug.DrawRay(this.transform.position, Vector2.down*1.5f, Color.red);
    }


    /* -- custom methods -- */

    //Indica si el personaje esta o no tocando el suelo
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask))
        {
            //ToDo: programar logica de contacto
            animator.enabled = true;
            return true;
        }
        else
        {
            //ToDo: programar logica de no contacto
            animator.enabled = false;   //se quedara con el ultimo frame de salto
            return false;
        }
    }

    //Hace que el persona salte si esta tocando el suelo
    void Jump(){
        if (IsTouchingTheGround()){
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
    }


}