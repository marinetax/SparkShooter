using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarMismo : MonoBehaviour
{

    void Update()
    {
         transform.Rotate (Vector3.down * 50 * Time.deltaTime, Space.Self);
    }
}
