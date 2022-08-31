using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Forward : MonoBehaviour
{

public float vel;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime* vel);
    }
}
