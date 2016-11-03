using UnityEngine;
using System.Collections;

public class ArmorManager : MonoBehaviour {

    /// <summary>
    /// armadura incial
    /// </summary>
    public int initialArmor = 3;
    /// <summary>
    /// armadura maxima
    /// </summary>
    public int maxArmor = 5;

    /// <summary>
    /// armadura actual
    /// </summary>
    public static int currentArmor;

    void Start()
    {
        currentArmor = initialArmor; // inicializamos la armadura actual
    }

    public void DestroyArmor()
    {
        currentArmor--; // restamos armadura
    }

    void OnTriggerEnter(Collider col) 
    {
        // al colisionar contra un paquete de armadura Y la armadura actual no es superior a la maxima posible
        if (col.gameObject.tag == "Armor" && currentArmor < maxArmor)
        {
            currentArmor++; // le sumamos uno
            Destroy(col.gameObject); // destruimos el objeto 
        }            
    }
}
