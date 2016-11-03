using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    /// <summary>
    /// velocidad de movimiento
    /// </summary>
    public float speed = 5;
    /// <summary>
    /// fuerza de salto
    /// </summary>
    public float jumpForce = 5;
    /// <summary>
    /// pie del personaje desde donde sale el Raycast para comprobar el suelo
    /// </summary>
    public Transform foot;
    /// <summary>
    /// distancia del Ray
    /// </summary>
    public float rayDistance;

    /// <summary>
    /// si el personaje esta en el suelo
    /// </summary>
    bool inGround;
    /// <summary>
    /// Rigidbody
    /// </summary>
    Rigidbody rb;
	
	void Start () {
        rb = GetComponent<Rigidbody>();
        inGround = true; // por defecto esta en el suelo
    }	
	
    void Update()
    {   
        // si el juego no esta parado
        if (!GameManager.pause)
            CheckForJump(); // compruebas si esta en el suelo y se puede saltar
    }

	void FixedUpdate () {
        // si el juego no esta parado
        if (!GameManager.pause)
        {
            Mov(); // movimiento
            Jump(); // salto
        }
	}

    void Jump()
    {
        if (inGround && Input.GetKeyDown(KeyCode.Space)) // si esta en el suelo y pulsas la barra espaciadora
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse); // saltas
        }
    }

    void Mov()
    {
        // vector movimiento normalizado para que no te muevas en diagonal mas rapido
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        
        // te mueves
        rb.MovePosition(rb.position + transform.rotation * input * speed * Time.fixedDeltaTime);
            
    }

    void CheckForJump()
    {
        RaycastHit hit; // informacion del Raycast
        Ray ray = new Ray(foot.position, Vector3.down); // ray que va desde la posicion del pie hacia abajo
        //Debug.DrawRay(foot.position, Vector3.down * rayDistance, Color.red);
        // si chocas
        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject.tag == "Ground")// si chocas contra el suelo
            {
                rb.drag = 3;
                inGround = true;  // estas en el suelo            
            }      
        }
        else
        {
            rb.drag = 0;
            inGround = false; // si no estas en el aire
        }
    }
}
