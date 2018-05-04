using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int puntuacion;
    float tiempo, tiempoFinal;
    



    public static GameManager instance = null;




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
        instance.Iniciar();
    }
    //Lo que tenga que hacer en el start
    void Iniciar()
    {
        puntuacion = 0;
        tiempo = Time.time;
    }

    public void FinPartida()
    {
        tiempoFinal = Time.time - tiempo;
        puntuacion = puntuacion + (int)Mathf.Round( tiempoFinal) * 100;
        SceneManager.LoadScene("Puntuacion");
    }

    public void SumaPuntos()
    {
        puntuacion = puntuacion + 50;
    }
}
