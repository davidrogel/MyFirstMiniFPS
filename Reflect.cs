using UnityEngine;
using System.Collections;

public class Reflect : MonoBehaviour {

    /// <summary>
    /// danho de la bala
    /// </summary>
    public int dmg = 1;
    /// <summary>
    /// velocidad del proyectil
    /// </summary>
    public float speed = 25;
    /// <summary>
    /// radio de colision frente a objetivos
    /// </summary>
    public float radius = 0.2f;
    /// <summary>
    /// LayerMask de colision contra extructuras
    /// </summary>
    public LayerMask collisonMask;
    /// <summary>
    /// cantidad de rebotes que puede hacer
    /// </summary>
    public int maxReflections = 10;

    /// <summary>
    /// cantidad de rebotes actuales
    /// </summary>
    int currentReflections;
    
	void Update () {
        // si el juego no esta pausado
        if (!GameManager.pause)
        {
            // movimiento de la bala con Translate
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            Reflection(); // metodo para reflejar el proyectil
            CollisionsDamage(); // metodo de colisiones para danho

            if (currentReflections >= maxReflections)// si los rebotes actuales es mayor o igual a los rebotes maximos
            {
                DestroyImmediate(gameObject); // destruyes el objeto
            }

            if (this != null)
                Invoke("Destroy", 30);
        }        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void Reflection()
    {
        RaycastHit hit; // Raycast que devuelve informacion
        Ray ray = new Ray(transform.position, transform.forward); // Ray del Raycast
        if (Physics.Raycast(ray, out hit, speed * Time.deltaTime * 2f, collisonMask)) // si cocha contra una pared
        {
            if (hit.collider) // si choca
                currentReflections++; // se añade 1 a la cantidad de rebotes actuales
            // la direccion de reflejo  = metodo Reflect que le pasamos la direccion del Ray y la normal del objeto que golpeamos
            Vector3 reflectionDir = Vector3.Reflect(ray.direction, hit.normal);
            // angulo con el que debe reflejar = 90 (para corregir el angulo de Unity) - Tangente de coseno y seno y lo pasamos a Grados
            float angle = 90 - Mathf.Atan2(reflectionDir.z, reflectionDir.x) * Mathf.Rad2Deg;
            // rotamos la bala en el angulo generado
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }

    void CollisionsDamage()
    {
        // si algun collider entra dentro del radio de accion lo guarda
        Collider[] colls = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider coll in colls) // para cada collider detectado
        {
            if(coll.gameObject.tag == "Objetive") // si es el objetivo
            {
                coll.gameObject.GetComponent<HealthSystem>().GetDamage(dmg); // le restas vida
                DestroyImmediate(gameObject); // destruyes la bala
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
