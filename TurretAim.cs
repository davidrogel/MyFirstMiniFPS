using UnityEngine;
using System;
using System.Collections;

public class TurretAim : MonoBehaviour {

    /// <summary>
    /// radio para apuntar al jugador
    /// </summary>
    public float radiusAim;
    /// <summary>
    /// posicion del canon
    /// </summary>
    public Transform cannon;

    /// <summary>
    /// script del ataque de la torreta
    /// </summary>
    TurretAttack scriptTurretAttack;

	void Start () {
        scriptTurretAttack = GetComponent<TurretAttack>();
    }
	
	void Update () {
        // si el juego no esta pausado
        if (!GameManager.pause)
            CheckForPlayer();
    }

    void CheckForPlayer()
    {
        // se recogen los colliders que haya a cierta distancia de la torreta
        Collider[] colls = Physics.OverlapSphere(transform.position, radiusAim);

        // para cada collider
        foreach (Collider coll in colls)
        {
            if (coll.gameObject.tag == "Player") // si es el jugador
            {
                // el canon apunta al objetivo
                cannon.LookAt(new Vector3(coll.transform.position.x, coll.transform.position.y - 2, coll.transform.position.z));
                // si se ataca al objetivo
                scriptTurretAttack.AttackPlayer(coll.gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, radiusAim);
    }
}
