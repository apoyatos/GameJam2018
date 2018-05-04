using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSombra : MonoBehaviour {

    public float speed = 1, smooth = 0.5f;



    
    Vector3 current;



	void Start () {
        current = Vector3.zero;
        
	}

    
    void Update () {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x - transform.position.x, Input.mousePosition.y- transform.position.y,0);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref current, speed, smooth); ;
	}
}
