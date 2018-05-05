using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour {

    public GameObject botones;
    public GameObject panelControles;
    //Métodos para el panel de opciones
    public void AbreControles()
    {
        botones.SetActive(false);
        panelControles.gameObject.SetActive(true);
    }
    public void CierraControles()
    {
        botones.SetActive(true);
        panelControles.gameObject.SetActive(false);
    }
}
