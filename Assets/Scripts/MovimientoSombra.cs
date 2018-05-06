using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSombra : MonoBehaviour {

    const float MARGEN = 0.3f;

    public float speed = 1, smooth = 0.5f;
    Vector2 aristaMinima, aristaMaxima;
    
    Vector3 current;
    Animator animacion;
    Rigidbody2D rb2D;

	void Start () {
        aristaMaxima = Camera.main.ViewportToWorldPoint(Camera.main.rect.max);
        aristaMinima = Camera.main.ViewportToWorldPoint(Camera.main.rect.min);
        current = Vector3.zero;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
	}

    
    void Update () {

        Vector3 target = Input.mousePosition;
        target.z = 10;
        target = Camera.main.ScreenToWorldPoint(target);
        

        Vector3 vel = rb2D.velocity;
        Vector2 aux = Vector3.SmoothDamp(transform.position, target, ref vel, smooth, speed);
        
        if(aux.x>=aristaMinima.x && aux.x <= aristaMaxima.x && aux.y >= aristaMinima.y && aux.y <= aristaMaxima.y)
        {
            rb2D.velocity = vel;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }

        
    }
}
