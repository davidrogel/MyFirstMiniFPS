using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    /// <summary>
    /// jugador
    /// </summary>
    public GameObject player;
    /// <summary>
    /// menu
    /// </summary>
    public GameObject menu;
    /// <summary>
    /// instrucciones
    /// </summary>
    public GameObject instructions;
    /// <summary>
    /// gameManager
    /// </summary>
    public GameManager manager;

    public void CloseMenu() // boton para cerrar el menu
    {
        menu.SetActive(false); // desactivas el menu
        GameManager.pause = false; // cancelas la pausa del juego
        Cursor.visible = false; // desactivas el cursor
    }

    public void OpenInstructions() // boton para activar las instrucciones
    {
        instructions.SetActive(true);
    }

    public void CloseInstructions() // boton para desactivar las instrucciones
    {
        instructions.SetActive(false);
    }

    public void RegeneratePlayer() // boton para regenerar el personaje
    {
        if(GameObject.FindGameObjectWithTag("Player") == null) // si el personaje no esta en la escena
        {
            Instantiate(player, new Vector3(0,1,0), Quaternion.identity); // se posiciona en el centro del juego
        }
    }

    public void RegenerateObjetives() // boton para regenerar objetivos
    {
        manager.RegenerateObjetives();
    }
}
