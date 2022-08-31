using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject balaOriginal;
    public float velocidad;
    public GameObject puntoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LanzarBala();
        }
    }

    void LanzarBala()
    {
        //Obtener la referencia del clon recien creado
        GameObject nuevaBala;
        nuevaBala = (GameObject)Instantiate(balaOriginal, puntoDisparo.transform.position, puntoDisparo.transform.rotation);
        Destroy(nuevaBala, 3f);

        //Obtener la referencia del Rigibody
        Rigidbody rigiDelClon;
        rigiDelClon = nuevaBala.GetComponent<Rigidbody>();

        //Velocidad
        rigiDelClon.velocity = puntoDisparo.transform.forward * velocidad * Time.deltaTime;
        //puntoDisparo.transform.Translate(0, 0, velocidad * Time.deltaTime);
    }
}

