using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    Rect rect;
	// Use this for initialization
	void Start () {
        rect = Camera.main.rect;
        ZonaMuerte zona = GameObject.FindObjectOfType<ZonaMuerte>();
        zona.transform.position = transform.position + new Vector3(0f, -Camera.main.ViewportToWorldPoint(rect.size).y - zona.GetComponent<Collider2D>().bounds.size.y*2f ,0f);
        GameObject[] bordes = GameObject.FindGameObjectsWithTag("Borde");
        bordes[0].transform.position = transform.position + new Vector3(Camera.main.ViewportToWorldPoint(rect.size).x + bordes[0].GetComponent<Collider2D>().bounds.size.x / 2f, 0f, 0f);
        bordes[1].transform.position = transform.position + new Vector3(-Camera.main.ViewportToWorldPoint(rect.size).x - bordes[1].GetComponent<Collider2D>().bounds.size.x / 2f, 0f, 0f);
    }
	
	
}
