using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public AudioSource ejemplo;
    public AudioClip musicaJuego;
    public float volumenMusicaJuego;
    public AudioClip musicaMenu;
    public float volumenMusicaMenu;
    public AudioClip musicaPuntuacion;
    public float volumenMusicaPuntuacion;

    AudioSource musica;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        instance.Iniciar();
    }

    void Iniciar()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Juego":
                ReproducirMusica(musicaJuego, volumenMusicaJuego);
                break;
            case "Menu":
                ReproducirMusica(musicaMenu, volumenMusicaMenu);
                break;
            case "Puntuacion":
                ReproducirMusica(musicaPuntuacion, volumenMusicaPuntuacion);
                break;
        }
    }
        
    void ReproducirMusica(AudioClip sonido, float volumen)
    {
        if(musica!=null)
            Destroy(musica.gameObject);
        musica = Instantiate(ejemplo);
        musica.loop = true;
        musica.volume = volumenMusicaJuego;
        musica.Play();
    }


    public IEnumerator ReproducirSonido(AudioClip audio, float volumen)
    {
        while (true)
        {
            AudioSource aux = Instantiate(ejemplo);
            aux.clip = audio;
            aux.Play();
            aux.volume = volumen;
            yield return aux;
            Destroy(aux.gameObject);
        }
    }


}
