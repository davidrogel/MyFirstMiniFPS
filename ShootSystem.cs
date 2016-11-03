using UnityEngine;
using System.Collections;

public class ShootSystem : MonoBehaviour {

    /// <summary>
    /// proyectil prefab
    /// </summary>
    public GameObject proyectil;
    /// <summary>
    /// posicion de las armas
    /// </summary>
    public Transform guns;
    /// <summary>
    /// boquilla del laser
    /// </summary>
    public Transform muzzleLaser;
    /// <summary>
    /// boquilla del reflect
    /// </summary>
    public Transform muzzleReflect;
    /// <summary>
    /// ratio de disparo
    /// </summary>
    public float shotRatio = 0.25f;

    /// <summary>
    ///  si esta activo el laser
    /// </summary>
    bool activeLaser;
    /// <summary>
    /// danho
    /// </summary>
    int damage = 1;
    /// <summary>
    ///  proximo disparo
    /// </summary>
    float nextShot;
    
	void Start () {
        activeLaser = false; // por defecto esta activa el arma de reflectar
    }	

	void Update () {
        // si el juego no esta parado
        if (!GameManager.pause)
        {
            // cambio de arma con el 1 y el 2
            if (Input.GetKeyDown(KeyCode.Alpha1))
                activeLaser = true;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                activeLaser = false;

            if (activeLaser)
                LaserShoot();
            else
                ReflectionShoot();
        }
        
    }

    void ReflectionShoot()
    {
        shotRatio = .5f; // ratio de disparo
        guns.GetChild(0).gameObject.SetActive(false); // desactivas Laser
        guns.GetChild(1).gameObject.SetActive(true); // activas Reflect

        if (Input.GetMouseButton(0) && Time.time > nextShot) // si pulsas Left Clic del Mouse
        {
            nextShot = Time.time + shotRatio;
            Instantiate(proyectil, muzzleReflect.position, muzzleReflect.rotation); // instancias el proyectil
        }
    }

    void LaserShoot()
    {        
        guns.GetChild(0).gameObject.SetActive(true); // activas Laser
        guns.GetChild(1).gameObject.SetActive(false); // desactivas Reflect

        if (Input.GetMouseButton(0) && Time.time > nextShot) // si pulsas Left Clic del Mouse
        {
            nextShot = Time.time + shotRatio;
            CheckHit(); // compruebas el hit
        }
    }

    void CheckHit()
    {
        RaycastHit hit; // informarcion del Raycast
        // si el Raycast golpea
        if(Physics.Raycast(muzzleLaser.position, muzzleLaser.forward, out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.tag == "Objetive") // si es el objetivo
            {
                DoDmg(damage, hit); // le haces danho
            }            
        }
    }

    void DoDmg(int dmg, RaycastHit hit) // le pasas el danho y la informacion del hit
    {
        HealthSystem scriptHealth = hit.collider.GetComponent<HealthSystem>(); // coges el script de la vida del objetivo
        if (scriptHealth != null) // si el script existe
            scriptHealth.GetDamage(dmg); // le haces danho
    }
}
