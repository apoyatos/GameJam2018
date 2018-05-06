using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFin : MonoBehaviour {

    static bool Encendido;

    void Start()
    {
        Text puntuacion = GetComponentInChildren<Puntuacion>().GetComponent<Text>();
        Text mejorPuntuacion = GetComponentInChildren<MejorPuntuacion>().GetComponent<Text>();
        funcionVacia a = () => {
            puntuacion.text = GameManager.instance.Puntuacion().ToString();
            mejorPuntuacion.text = GameManager.instance.MejorPuntuacion().ToString();
            gameObject.SetActive(true);
            Encendido = true;
        };
        GameManager.instance.Fin += a;
        gameObject.SetActive(false);
        Encendido = false;
    }
    public static bool Activa()
    {
        return Encendido;
    }
}
