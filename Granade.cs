using UnityEngine;
using System.Collections;

// requiere el componente Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class Granade : MonoBehaviour {

    /// <summary>
    /// a la velicidad que sale la granada
    /// </summary>
    public float impulseForce = 10f;
    /// <summary>
    /// radio de colision
    /// </summary>
    public float radius = 0.13f;
    /// <summary>
    /// tiempo hasta que explota
    /// </summary>
    public float explodeTime = 1f;

    /// <summary>
    /// splipt de la Explosion
    /// </summary>
    ExplotionGranade scriptExplotion;
    /// <summary>
    /// Rigidbody
    /// </summary>
    Rigidbody rb;

	void Start () {
        // componente Rigidbody
        rb = GetComponent<Rigidbody>();
        // componente script de la explosion
        scriptExplotion = GetComponent<ExplotionGranade>();
    }
	
	void Update () {
        // si el juego no esta pausado
        if (!GameManager.pause)
            // movimiento de la granada mediante Transform
            transform.Translate(Vector3.forward * impulseForce * Time.deltaTime);        
    }

    void FixedUpdate()
    {
        // si el juego no esta pausado
        if (!GameManager.pause)
            Collisions(); // metodo para las colisiones
    }

    void Collisions()
    {
        // colliders dentro de una esfera
        Collider[] colls = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider coll in colls) // para cada collider
        {
            // si el collider es alguno de estos tags
            if(coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Objetive" || coll.gameObject.tag == "Turret")
            {
                impulseForce = 0; // ponemos la velocidad a 0 para que no se mueva    
                rb.isKinematic = true; // volvemos al Rigidbody kinematico para que no se mueva por la gravedad
                Invoke("Explode", explodeTime); // invocamos al metodo explotar tras un retardo
            }
        }
    }

    void Explode()
    {
        scriptExplotion.Explotion(); // llamamos al metodo explotar del script te explosiones
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
