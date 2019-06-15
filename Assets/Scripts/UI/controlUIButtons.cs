﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlUIButtons : MonoBehaviour
{
    public Animator fade;
    public GameObject FadePanel;

    public AudioSource cambiarOpcionSound;
    public AudioSource tickSound;
    public AudioSource sonidoRegresar;

   /* public static string PreviousScene = "";

    public void LoadScene(string sceneName)
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }*/


    // Start is called before the first frame update
    void Start()
    {



    }


    public void sonidoCambiarOpcion()
    {
        cambiarOpcionSound.Play();
    }

    public void tickSonidoSound()
    {
        tickSound.Play();
    }

    public void playSonidoRegresar()
    {
        sonidoRegresar.Play();
    }


    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menus");
    }

    public void NuevaPartida()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level 1");

    }

    public void Fade()
    {
        FadePanel.SetActive(true);
        fade.SetBool("FadingTime", true);
        StartCoroutine("EsperaQueFade");
    }

    public void CerrarPartida()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    IEnumerator EsperaQueFade()
    {
      
        yield return new WaitForSeconds(0.4f);
        fade.SetBool("FadingTime", false);
        FadePanel.SetActive(false);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cambiarOpcionSound.Play();
        }

        if (fade == null)
        {
            fade = GameObject.Find("FadePanel").GetComponent<Animator>();
        }
    }
}
