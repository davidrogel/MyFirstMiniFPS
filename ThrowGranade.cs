using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowGranade : MonoBehaviour {

    /// <summary>
    /// granada prefab
    /// </summary>
    public GameObject granade;
    /// <summary>
    /// posicion de la mano desde donde sale la granada
    /// </summary>
    public Transform hand;
    /// <summary>
    /// tiempo entre lanzamiento de granadas
    /// </summary>
    public float timeBetweenThrows = 1.5f;
    
    /// <summary>
    /// proximo lanzamiento
    /// </summary>
    float nextThrow;

	void Update () {
        // si el juego no esta pausado
        if (!GameManager.pause)
        {
            // si pulsas la Q
            if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextThrow)
            {
                nextThrow = Time.time + timeBetweenThrows;
                // instancias la granada en la posicion del a mano y con la rotacion de la mano
                Instantiate(granade, hand.position, hand.rotation);
            }
        }        
	}
}
