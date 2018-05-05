using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Text>().text = "MEJOR PUNTUACION: " + GameManager.instance.MejorPuntuacion();

    }
}
