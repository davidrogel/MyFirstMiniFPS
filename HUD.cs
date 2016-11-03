using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    /// <summary>
    /// texto de la vida
    /// </summary>
    public Text liveText;
    /// <summary>
    /// texto de la armadura
    /// </summary>
    public Text armorText;
    
    void Update()
    {
        // mostramos en pantalla la vida y la amadura del jugador
        if(GameObject.FindGameObjectWithTag("Player") != null)
            liveText.text = "Health: " + GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().GetCurrentLife().ToString();
        armorText.text = "Armor: " + ArmorManager.currentArmor.ToString();
    }
}
