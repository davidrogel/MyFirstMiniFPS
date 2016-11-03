using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

    /// <summary>
    /// sensibilidad en el eje X
    /// </summary>
    public float sensibilidadX = 3.5f;
    /// <summary>
    /// sensibilidad en el eje Y
    /// </summary>
    public float sensibilidadY = 3.5f;
    /// <summary>
    /// cap de rotation hacia arriba
    /// </summary>
    public float capTop = -80;
    /// <summary>
    /// cap de rotation hacia abajo
    /// </summary>
    public float capBot = 80;

    /// <summary>
    /// Transform de la camara
    /// </summary>
    Transform camara;
    /// <summary>
    /// valor de rotacion de la camara
    /// </summary>
    float camaraRotation;
	
	void Start () {
        // cogemos el transform de la camara principal
        camara = Camera.main.transform;
	}
	
	void Update () {
        // si el juego no esta parado
        if (!GameManager.pause)
            FirstPersonControl();
    }

    void FirstPersonControl()
    {
        // rotamos el personaje con el raton en el eje X
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensibilidadX);

        // determinamos como se rotara la camara ( con el raton en el eje Y)
        camaraRotation -= Input.GetAxis("Mouse Y") * sensibilidadY;
        // delimitamos la rotacion para que no rote 360 grados
        camaraRotation = Mathf.Clamp(camaraRotation, capTop, capBot);
        // y se la añadimos a la rotacion local de la camara
        camara.localEulerAngles = Vector3.right * camaraRotation;
    }
}
