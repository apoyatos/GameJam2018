using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour {

    Text texto;
	void Start () {
        texto = gameObject.GetComponent<Text>();
        texto.text = "Puntuacion: " + GameManager.instance.Puntuacion();
    }
	
}
