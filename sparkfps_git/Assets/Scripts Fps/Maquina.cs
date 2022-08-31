using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Maquina : MonoBehaviour
{
    public GameObject lataescudo;
    public GameObject latavida;
    public GameObject latabalas;
    public float puntos = 0;
    public float enemigovida = 100;

    public GameObject LATAS;
    public GameObject mensaje;
    public GameObject mensaje2;

    public TMP_Text ppuntos;

    //public Animator caida;
    //public Animator caidas;
    //public Animator caidass;
    //public Animator caidas;

    // Start is called before the first frame update
    void Start()
    {
        mensaje.SetActive(false);
        mensaje2.SetActive(false);
        GetComponent<vidaEnemy>();
        vidaEnemy.puntos = 0;
        //caida.SetBool("lata", false);
        //caidas.SetBool("latas", false);
        //caidass.SetBool("latas", false);
    }

    // Update is called once per frame
    void Update()
    {

       
        ppuntos.text = "" + vidaEnemy.puntos;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mensaje2.SetActive(true);

            if (vidaEnemy.puntos <= 499)
            {
                mensaje.SetActive(true);
                Debug.Log("Consigue mas puntos");
            }
         

            if ((vidaEnemy.puntos >= 500) && (Input.GetKey(KeyCode.E)))
            {
                Instantiate(lataescudo, LATAS.transform.position, this.transform.rotation);
                //lataescudo.SetActive(true);
                Debug.Log("lata escudo");
                //caida.SetBool("lata", true);
                mensaje.SetActive(false);
                vidaEnemy.puntos = vidaEnemy.puntos - 500;
                ppuntos.text = "" + vidaEnemy.puntos;

            }
            if ((vidaEnemy.puntos >= 500) && (Input.GetKey(KeyCode.B)))
            {
                Instantiate(latabalas, LATAS.transform.position, this.transform.rotation);
                //latabalas.SetActive(true);
                //caidas.SetBool("latas", true);
                vidaEnemy.puntos = vidaEnemy.puntos - 500;
                ppuntos.text = "" + vidaEnemy.puntos;
                Debug.Log("lata balas");
                mensaje.SetActive(false);
            }
            if ((vidaEnemy.puntos >= 500) && (Input.GetKey(KeyCode.V)))
            {
                Instantiate(latavida, LATAS.transform.position, this.transform.rotation);
                //latavida.SetActive(true);
                //caidass.SetBool("latass", true);
                vidaEnemy.puntos = vidaEnemy.puntos - 500;
                ppuntos.text = "" + vidaEnemy.puntos;
                Debug.Log("lata vida");
                mensaje.SetActive(false);
            }



        }


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (vidaEnemy.puntos <= 499)
            {
                mensaje.SetActive(true);
                Debug.Log("Consigue mas puntos");
            }
        }
        mensaje.SetActive(false);
        mensaje2.SetActive(false);
    }


    


    //private void OnColliderEnter(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        if (vidaEnemy.puntos <= 100)
    //        {
    //            Debug.Log("Consigue mas puntos");
    //        }

    //        if ((vidaEnemy.puntos >= 100) && (Input.GetKey(KeyCode.E)))
    //        {
    //            Instantiate(lataescudo, LATAS.transform.position, this.transform.rotation);
    //            //lataescudo.SetActive(true);
    //            Debug.Log("lata escudo");
    //            caidas.SetBool("caers", true);
    //            vidaEnemy.puntos = vidaEnemy.puntos - 100;
    //            ppuntos.text = "" + vidaEnemy.puntos;

    //        }
    //        if ((vidaEnemy.puntos >= 100) && (Input.GetKey(KeyCode.B)))
    //        {
    //            Instantiate(latabalas, LATAS.transform.position, this.transform.rotation);
    //            //latabalas.SetActive(true);
    //            caida.SetBool("caer", true);
    //            vidaEnemy.puntos = vidaEnemy.puntos - 100;
    //            ppuntos.text = "" + vidaEnemy.puntos;
    //            Debug.Log("lata balas");
    //        }
    //        if ((vidaEnemy.puntos >= 100) && (Input.GetKey(KeyCode.V)))
    //        {
    //            Instantiate(latavida, LATAS.transform.position, this.transform.rotation);
    //            //latavida.SetActive(true);
    //            caida.SetBool("caer", true);
    //            vidaEnemy.puntos = vidaEnemy.puntos - 100;
    //            ppuntos.text = "" + vidaEnemy.puntos;
    //            Debug.Log("lata vida");
    //        }



    //    }

}

