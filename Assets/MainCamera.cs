using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    Rect rect;
	// Use this for initialization
	void Start () {
        rect = Camera.main.rect;
        Vector2 tam = rect.size;
        tam = new Vector2 (240 /Camera.main.scaledPixelWidth * tam.x, 360 / Camera.main.scaledPixelHeight * tam.y);
        rect.size = tam;

    }
	
	
}
