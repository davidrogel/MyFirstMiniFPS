using UnityEngine;
using System.Collections;

public class TurretBullet : MonoBehaviour {

    /// <summary>
    /// velocidad de la bala
    /// </summary>
    public float speed = 10;
    /// <summary>
    /// radio de efecto de la bala
    /// </summary>
    public float radius;

    /// <summary>
    /// danho de la bala
    /// </summary>
    int dmg = 1;
    	
	void Update () {
        if (!GameManager.pause)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime); // movimiento bala
            CollisionsDamage(); // metodo para comprobar colisiones

            if (this != null)
                Invoke("Destroy", 20);
        }        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void CollisionsDamage()
    {
        // si algun collider entra dentro del radio de accion lo guarda
        Collider[] colls = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider coll in colls) // para cada collider detectado
        {
            if (coll.gameObject.tag == "Player") // si es el jugador
            {
                if (coll.gameObject.GetComponent<HealthSystem>() != null && ArmorManager.currentArmor == 0)
                    coll.gameObject.GetComponent<HealthSystem>().GetDamage(dmg); // le restas vida
                else
                    coll.gameObject.GetComponent<ArmorManager>().DestroyArmor();
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
