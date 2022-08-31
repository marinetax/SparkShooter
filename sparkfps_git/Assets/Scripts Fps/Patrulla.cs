using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
    public GameObject punto1;
    public GameObject punto2;

    public GameObject jugador;

    public GameObject BalaPrin;
    public GameObject SpawnBala;

    public int destActual;

    public float cadencia;
    public float TiempoEspera = 2;

    public NavMeshAgent agente;

    public float margen = 1;
    public float rango = 6;


    // Start is called before the first frame update
    void Start()
    {
        agente = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        DetectaralPlayer();
       
        //El cubo ira de un punto a otro cuando no detecte al player.

        Vector3 dist = this.transform.position - agente.destination;
        if (dist.magnitude < margen)
        {
            if (destActual == 1)
            {
                destActual = 2;

                agente.SetDestination(punto2.transform.position);
            }
            else
            {
                destActual = 1;
                agente.SetDestination(punto1.transform.position);

            }


        }
         

        void DetectaralPlayer()
        {
            Vector3 distPlayer = jugador.transform.position - this.transform.position;

            if (distPlayer.magnitude <= rango)
            {
                RaycastHit resultRayo;

                if (Physics.Raycast(this.transform.position, distPlayer, out resultRayo, 100))
                {
                    if (resultRayo.transform.tag == "Player")
                    {

                        float anguelo = Vector3.Angle(this.transform.up, distPlayer);

                        agente.SetDestination(jugador.transform.position);

                        if (cadencia <= 0)
                        {

                            cadencia = TiempoEspera;
                            Instantiate(BalaPrin, SpawnBala.transform.position, this.transform.rotation);


                        }
                    }


                }
            }


            cadencia -= Time.deltaTime;

        }
    }
  
}
