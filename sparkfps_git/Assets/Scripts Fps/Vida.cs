using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Vida : MonoBehaviour
{

    public TMP_Text pvida;
    public float vida = 100;
    public TMP_Text pescudo;
    public float escudo = 100;
    public GameObject final;

    //public GameObject enemyfinal; 


    public GameObject particula;
    Raycast raycast;
    public Image blood;
    private float r;
    private float a;
    private float g;
    private float b;
    public GameObject IESCUDO;
    public GameObject IVIDA;

    public GameObject mensaje;

    // Start is called before the first frame update
    void Start()
    {
        IESCUDO.SetActive(false);
        IVIDA.SetActive(false);
        pescudo.text = "" + escudo;
        pvida.text = ""+vida;
        final.SetActive(false);
        //enemyfinal.SetActive(false);
        mensaje.SetActive(false);
        r = blood.color.r;
        a = blood.color.a;
        b = blood.color.b;
        g = blood.color.g;
        
    }



    // Update is called once per frame
    void Update()
    {

        if (vida <= 60)
        {
            a += 0.01f;

        }
        a -= 0.001f;
        a = Mathf.Clamp(a, 0, 1f);
        ChangeColor();

        if (escudo > 0)
        {
            a -= 0.01f;
            a = Mathf.Clamp(a, 0, 1f);
            ChangeColor();
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "BESCUDO")
        {
            escudo = escudo + 50;
            pescudo.text = "" + escudo;
            Debug.Log(escudo);
           
            IESCUDO.SetActive(true);
            Destroy(other.gameObject, 0.2f);
            a -= 0.001f;
            a = Mathf.Clamp(a, 0, 1f);
            ChangeColor();

            if (escudo <= 0)
            {
                pescudo.text = "" + escudo;
                IESCUDO.SetActive(false);
            }
        }

        if (other.gameObject.tag == "BVIDA")
        {
            vida = vida + 100;
            pvida.text = "" + vida;
            IVIDA.SetActive(true);
            Destroy(other.gameObject);
          
        }
        if (other.gameObject.tag == "BEnemy")
        {
            escudo = escudo - 10;
            pescudo.text = "" + escudo;
            if (escudo <= 0)
            {
                escudo = 0;
                pescudo.text = "" + escudo;
                vida = vida - 10;
                pvida.text = "" + vida;
                Debug.Log(vida);
                IESCUDO.SetActive(false);
                if (vida <= 0)
                {
                    SceneManager.LoadScene("Derrota");
                }


            }

        }




        if (other.gameObject.tag == "boton")
        {
            
            Debug.Log("Ha encontrado una pieza");
            Destroy(other.gameObject, 0.2f);
           
            final.SetActive(true);
            //particula.SetActive(true);
            //enemyfinal.SetActive(true);
           
          
        }

        if (other.gameObject.tag == "botone")
        {
            Debug.Log("Has de encontrar la pieza");
            mensaje.SetActive(true);
     
        }
       
        if (other.gameObject.tag == "Final")
        {
            Debug.Log("collison");
            SceneManager.LoadScene("Victoria");
        }


        if (other.gameObject.tag == "Botiquin")
        {
            vida = vida + 50;
            pvida.text = "" + vida;
            Debug.Log(vida);
            Destroy(other.gameObject);
            a -= 0.001f;
            a = Mathf.Clamp(a, 0, 1f);
            ChangeColor();

        }




    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "botone")
        {
            
            mensaje.SetActive(false);
            
        }

      
    }


        private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        blood.color = c;
    }

   
}
