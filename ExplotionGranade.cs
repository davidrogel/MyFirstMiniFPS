using UnityEngine;
using System.Collections;

public class ExplotionGranade : MonoBehaviour {

    /// <summary>
    /// LayerMask que comprueba si el es objetivo
    /// </summary>
    public LayerMask objetiveMask;
    /// <summary>
    /// potencia de la explosion
    /// </summary>
    public float explotionPower;
    /// <summary>
    /// radio de la explosion
    /// </summary>
    public float radiusExplotion;
    
    public void Explotion()
    {
        // Recoge los colliders que haya en una esfera al rededor de la granada y solo cogerá el collider del objetivo
        Collider[] colls = Physics.OverlapSphere(transform.position, radiusExplotion, objetiveMask);

        foreach(Collider coll in colls) // para cada uno de ellos
        { 
            // informacion del Raycast
            RaycastHit hit;
            // Ray que va desde la granada hasta el objetivo
            Ray ray = new Ray(transform.position, coll.gameObject.transform.position - transform.position);            
            // si golpea
            if(Physics.Raycast(ray, out hit))
            {   
                // lo que golpea es el objetivo y no hay ningun muro por medio
                if(!(hit.collider.tag == "Wall") && hit.collider.tag == "Objetive")
                {
                    // si el objetivo tiene Rigidbody
                    if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
                        // le aplica la explosion
                        hit.collider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explotionPower, transform.position, radiusExplotion);
                }
            }
        }
        // Desaparece
        Disable();
    }

    void Disable()
    {
        // la granada se desactiva
        gameObject.SetActive(false);
        // para que no se acumulen se destruye despues de 5 segundos
        Invoke("Destroy", 5);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radiusExplotion);
    }
}
