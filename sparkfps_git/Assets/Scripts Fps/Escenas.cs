using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }
    public AudioSource sonido;
    public void play()
    {
        sonido.Play();
        SceneManager.LoadScene("Fps");
        Cursor.visible = true;
    }

    public void exit()
    {
        sonido.Play();
        Application.Quit();
        Debug.Log("Saliendo del juego");
        Cursor.visible = true;

    }

    public void menu()
    {
        sonido.Play();
        SceneManager.LoadScene("TestMenu");
        Cursor.visible = true;

    }
}
