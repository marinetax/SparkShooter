using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IACUBO : MonoBehaviour
{
    public float margen = 1;
    public float rango = 4;
    public NavMeshAgent agente;

    public GameObject jugador;
    public float distancia;
    public NavMeshAgent miperso;

    public float cadencia;
    public float TiempoEspera = 2;
    public GameObject luz;
    public GameObject BalaPrin;
    public GameObject SpawnBala;

    
    // Start is called before the first frame update
    void Start()
    {
        luz.SetActive(false);
        //NavMesh
        agente = this.GetComponent<NavMeshAgent>();
        miperso = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        miperso.SetDestination(jugador.transform.position);
        DetectaralPlayer();
    }

    //Cuando detecten al Player a una cierta distancia lo sgeuiran y empezaran a disparar balas.
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
                    float anguelo = Vector3.Angle(this.transform.forward, distPlayer);

                    agente.SetDestination(jugador.transform.position);
                    if (cadencia <= 0)
                    {
                        
                        cadencia = TiempoEspera;
                        Instantiate(BalaPrin, SpawnBala.transform.position, this.transform.rotation);
                        luz.SetActive(true);


                    }
                }


            }
        }
        
        //Cadencia de los cubos para que no saquen balas sin parar
        cadencia -= Time.deltaTime;
        
    }
   

}
