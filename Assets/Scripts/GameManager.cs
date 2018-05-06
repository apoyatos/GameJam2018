using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void funcionVacia();

public class GameManager : MonoBehaviour {

    int mejorPuntuacion=0;
    int puntuacion;
    float tiempo, tiempoFinal;

    public float multiplicadorPuntuacionTiempo;
    public funcionVacia Fin;
    public funcionVacia Pausa =()=> { };
    public int puntosPorDestruirRocas;
    
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
        Fin = () => { };
        Pausa = () => { };
        puntuacion = 0;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Juego" && Input.GetKeyDown(KeyCode.Escape) && !PanelFin.Activa())
            Pausa();
    }

    public void IniciarCronometro()
    {
        tiempo = Time.time;
    }

    public void FinPartida()
    {
        tiempoFinal = Time.time - tiempo;
        puntuacion = puntuacion + (int)(Mathf.Round( tiempoFinal) * multiplicadorPuntuacionTiempo);
        Cursor.visible = true;
        Fin();
    }

    public void SumaPuntos(int puntos)
    {
        puntuacion = puntuacion + puntos;
    }

    public int Puntuacion()
    {
        return puntuacion;
    }

    public void Cargajuego()
    {
        SceneManager.LoadScene("Juego");
    }
    public void CargaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public int MejorPuntuacion()
    {
        if (puntuacion > mejorPuntuacion)
            mejorPuntuacion = puntuacion;
        return mejorPuntuacion;
    }
    
}
