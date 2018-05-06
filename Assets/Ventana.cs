using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventana : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        Screen.SetResolution(480, 720, false);
        Screen.fullScreen = false;
	}
}
