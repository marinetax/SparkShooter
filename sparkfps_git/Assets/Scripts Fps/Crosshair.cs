using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private RectTransform CrosshairExt;

    public GameObject player;

    public float idleSize = 40f;
    public float walkSize = 60f;
    public float runSize = 70f;
    public float currentSize = 40f;
    public float speed = 10f;


  private void Update()
    {
        if (Caminar)
        {
            currentSize = Mathf.Lerp(currentSize, walkSize, Time.deltaTime * speed);
        }
        else if (Correr /*|| Saltar*/)
        {
            currentSize = Mathf.Lerp(currentSize, runSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, idleSize, Time.deltaTime * speed);
        }

        CrosshairExt.sizeDelta = new Vector2(currentSize, currentSize);
    }       




    bool Caminar
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if(Input.GetKey(KeyCode.LeftShift) == false /*&& !Saltar*/)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    bool Correr
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if(Input.GetKey(KeyCode.LeftShift) == true /*&& !Saltar*/)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

/*   bool Saltar
    {
        get
        {
            if (player.GetComponent<Rigidbody First Person Controller">().m_IsGrounded == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   }
*/
}

