using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public AudioSource ejemplo;
    public AudioClip musicaJuego;
    public float volumenMusicaJuego;


    AudioSource musica;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ReproducirMusica(musicaJuego, volumenMusicaJuego);
        }
        else
            Destroy(gameObject);
        

    }


    void ReproducirMusica(AudioClip sonido, float volumen)
    {
        musica = Instantiate(ejemplo);
        musica.loop = true;
        musica.volume = volumenMusicaJuego;
        musica.clip = sonido;
        musica.Play();
        DontDestroyOnLoad(musica);
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
