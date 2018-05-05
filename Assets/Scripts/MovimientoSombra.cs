using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSombra : MonoBehaviour {

    public float speed = 1, smooth = 0.5f;



    
    Vector3 current;
    Animator animacion;
    Rigidbody2D rb2D;

	void Start () {
        current = Vector3.zero;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
	}

    
    void Update () {

        Vector3 target = Input.mousePosition;
        target.z = 10;
        target = Camera.main.ScreenToWorldPoint(target);


        Vector3 vel = rb2D.velocity;
        rb2D.position = Vector3.SmoothDamp(transform.position, target, ref vel, smooth, speed);
        rb2D.velocity = vel;
    }
}
