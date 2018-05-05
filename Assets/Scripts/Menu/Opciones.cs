using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opciones : MonoBehaviour {

    public GameObject botones;
    public GameObject panelOpciones;
    //Métodos para el panel de opciones
    public void AbreOpciones()
    {
        botones.SetActive(false);
        panelOpciones.gameObject.SetActive(true);
    }
    public void CierraOpciones()
    {
        botones.SetActive(true);
        panelOpciones.gameObject.SetActive(false);
    }
}
