using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcadorBoton : MonoBehaviour {

    Text texto;

    void Start()
    {
        texto = GetComponentInChildren<Text>();
    }
    public void Entrar()
    {
        texto.fontStyle = FontStyle.Bold;
    }

    public void Salir()
    {
        texto.fontStyle = FontStyle.Normal;
    }


}
