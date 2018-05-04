using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Caer : ObjetoEscena {

    public float velocidadCaida;

    Rigidbody2D rb2D;

	
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0f;
        rb2D.velocity = Vector2.down * velocidadCaida;
        rb2D.isKinematic = true;
	}

    //Cambia la velocidad del objeto a velocidad.
    public void cambiarVelocidad(float velocidad)
    {
        velocidadCaida = velocidad;
        if (rb2D != null)
        {
            rb2D.velocity = Vector2.down * velocidadCaida;
        }
    }

    //Cambia la velocidad del objeto a una velocidad aleatoria entre minimo y maximo.
    public void cambiarVelocidadAleatorio(float minimo, float maximo)
    {
        float velocidad = Random.Range(minimo, maximo);
        cambiarVelocidad(velocidad);
    }

    public override void Muerte()
    {
        Destroy(gameObject);
    }
}
