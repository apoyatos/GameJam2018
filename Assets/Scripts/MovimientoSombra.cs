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

        Vector3 target = Input.mousePosition;
        target.z = 10;
        target = Camera.main.ScreenToWorldPoint(target);


        
        transform.position = Vector3.SmoothDamp(transform.position, target, ref current, speed, smooth); 
        //transform.position = Vector3.Lerp(transform.position, Input.mousePosition, smooth);
        

    }
}
