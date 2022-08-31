using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class vidaEnemy : MonoBehaviour
{
    public static float puntos = 0;
    public float enemigovida = 0;
  
    public TMP_Text ppuntos;

    public GameObject efectom;
    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        efectom.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ppuntos.text = "" + puntos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Perdera vida al chocar con los enemigos
        if (collision.gameObject.tag == "bala")
        {
            enemigovida = enemigovida -  50;



           

            if (enemigovida <= 0)
            {
                efectom.SetActive(true);
                Destroy(this.gameObject, 0.5f);
                
              
            }
            if (enemigovida == 0)
            {
                puntos = puntos + 50;
                ppuntos.text = "" + puntos;
            }
        }
    }

  
    
}
