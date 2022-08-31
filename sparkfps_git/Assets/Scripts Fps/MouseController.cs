using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public float mouse = 100f;
    public Transform cam;

    // Start is called before the first frame update

    float mousex;
    float mousey;
    float yReal = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        mousex = Input.GetAxis("Mouse X") * mouse * Time.deltaTime;
        mousey = Input.GetAxis("Mouse Y") * mouse * Time.deltaTime;
        yReal -= mousey;

        yReal = Mathf.Clamp(yReal, -120f, 120f);
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);
        transform.Rotate(Vector3.up * 2 * mousex);

         
        
    }
}
