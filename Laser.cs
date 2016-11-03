using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    /// <summary>
    /// LineRenderer
    /// </summary>
    LineRenderer laser;

	void Start () {
        // cogemos el compenente adecuado
        laser = GetComponent<LineRenderer>();
	}
	
	void Update () {
        // si el juego no esta pausado
        if (!GameManager.pause)
            LaserDistance();
    }

    void LaserDistance()
    {
        RaycastHit hit; // RaycastHit para obtener informacion del Raycast

        // Un Raycast que va desde la posicion del laser hacia delante
        // si toca con algo
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // el LineRenderer, la posicion 1 es igual a la adistancia del Raycast
            laser.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
        else
        {
            // si no la distancia es de 5000
            laser.SetPosition(1, new Vector3(0, 0, 5000));
        }
    }
}
