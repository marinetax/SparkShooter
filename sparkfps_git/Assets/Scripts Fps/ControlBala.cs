using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{
    public float bala;
    public GameObject prefab;


    void Update()
    {

        //Velocidad a la que la bala saldra disparada que podremos
        //modificar en el PREFAB.

        this.transform.Translate(0, 0, bala * Time.deltaTime);
        Destroy(this.gameObject, 1f);




    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
           
            Destroy(this.gameObject);
        }

    }


    }

        

