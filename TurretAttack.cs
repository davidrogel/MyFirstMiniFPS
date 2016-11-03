using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour {

    /// <summary>
    /// bala 
    /// </summary>
    public GameObject turretBullet;
    /// <summary>
    /// salida bala
    /// </summary>
    public Transform turretMuzzle;
    /// <summary>
    /// cada cuanto se lanza una bala
    /// </summary>
    public float shotRatio = 2f;

    /// <summary>
    ///  tiempo para la proxima bala
    /// </summary>
    float nextShot;

    public void AttackPlayer(GameObject player)
    {
        if(Time.time > nextShot)
        {
            nextShot = Time.time + shotRatio;
            // se instancia la bala en la posicion de la salida
            Instantiate(turretBullet, turretMuzzle.position, turretMuzzle.rotation);
        }
    }
}
