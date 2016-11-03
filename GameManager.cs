using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// variable estatica para pausar el juego
    /// </summary>
    public static bool pause;
    /// <summary>
    /// menu
    /// </summary>
    public GameObject menu;
    /// <summary>
    /// los objetivos en la escena
    /// </summary>
    public GameObject[] objetives;
    /// <summary>
    /// el prefab de objetivo generico
    /// </summary>
    public GameObject objetivePrefab;

    /// <summary>
    /// Lista que guarda cada uno de los objetivos
    /// </summary>
    List<GameObject> objs = new List<GameObject>();
    /// <summary>
    /// posicion inicial de los objetivos
    /// </summary>
    Vector3[] initialObjetivePosition;

    void Start () {
        // inicializamos el array de posiciones
        initialObjetivePosition = new Vector3[objetives.Length];

        for (int i = 0; i < objetives.Length; i++)
        {
            // lo llenamos con las posiciones iniciales de los objetivos
            initialObjetivePosition[i] = objetives[i].transform.position;
            // y llenamos la lista con los objetivos
            objs.Add(objetives[i]);
        }

        Cursor.visible = false; // desabilitar el cursor
        pause = false; // la pausa se extablece como falsa
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) // si pulsas la tecla P
        {
            if(!menu.activeSelf) // si el menu no esta activo
                menu.SetActive(true); // lo activas
            Cursor.visible = true; // haces visible es cursor
            pause = true; // pausas el juego
        }

        if (Input.GetKeyDown(KeyCode.Escape))//cerrar el juego
        {
            Application.Quit();
        }
    }

    public void RegenerateObjetives()
    {
        foreach(GameObject obj in objs) // para cada objetivo en la Lista
        {
            if(obj != null) // si no es nulo
                Destroy(obj); // lo eliminas
        }
        objs.Clear(); // limpias la Lista por si acaso
        for (int i = 0; i < initialObjetivePosition.Length; i++) 
        {
            // instancias de nuevo los Objetivos
            var go = Instantiate(objetivePrefab, initialObjetivePosition[i], Quaternion.identity) as GameObject;
            objs.Add(go); // los añades a la lista
        }
    }
}
