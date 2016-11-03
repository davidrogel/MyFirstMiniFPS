using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

    /// <summary>
    /// vida inicial
    /// </summary>
    public int initialLife = 3;

    /// <summary>
    /// vida actual
    /// </summary>
    int currentLife;
    
	void Start () {
        // igualamos la vida incial a la actual para establecer la vida del objeto
        currentLife = initialLife;
    }

    void Update()
    {
        //print(gameObject.name + currentLife);
    }

    // metodo para que el objeto reciva daño
    public void GetDamage(int dmg)
    {
        currentLife -= dmg; // le restas la cantidad de vid

        if (currentLife <= 0) // si la vida es 0
            Die(); // se desactiva
    }

    void Die()
    {
        Destroy(gameObject);
        //this.gameObject.SetActive(false);
    }

    public int GetCurrentLife()
    {
        return currentLife;
    }
}
