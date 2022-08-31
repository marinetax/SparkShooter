using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;
    public float jumpForce = 1f;

    // grave
    Vector3 velocity;
    public float gravity = -15f;
    public Transform groundcheck;
    bool isGrounded = false;
    float radius = 0.4f;

    //audios
    public AudioSource jump;
    public AudioSource pasos;
    public LayerMask mask;

    //powerups
    public Animator recoil;


    private void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, radius, mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;
            
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

       

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            recoil.SetTrigger("caminar");
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
            jump.Play();
            
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed= speed * 2f;
            recoil.SetBool("correr0", true);

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12;
            recoil.SetBool("correr0", false);
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            pasos.Play();
            recoil.SetBool("normal", true);

        }
        if (Input.GetButtonUp("Horizontal"))
        {
            pasos.Pause();
            recoil.SetBool("normal", false);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            pasos.Play();
            recoil.SetBool("normal", true);
        }
        if (Input.GetButtonUp("Vertical"))
        {
            recoil.SetBool("normal", false);
            pasos.Pause();
        }
        if((Input.GetButtonUp("Vertical") && (Input.GetKeyDown(KeyCode.LeftShift))))
            {
            recoil.SetBool("correr0", true);
            recoil.SetBool("normal", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        //if (other.gameObject.tag == "BBALAS")
        //{
        //    IBALAS.SetActive(true);
        //    Destroy(other.gameObject, 0.5f);
        //}
       
      

    }

    }
