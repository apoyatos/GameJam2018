using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatNube : Plataforma {
    
    public float tempDestruccion = 3f;
    public Color alpha;
    public AudioClip sonidoDesvanecerse;
    public float volumenDesvanecerse;

    bool tocada = false;

	// Use this for initialization
	void Start ()
    {
        alpha = GetComponent<SpriteRenderer>().color;
        alpha.a = 1;
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if(!tocada && col.collider.tag == "Luz")
        {
            SoundManager.instance.ReproducirSonido(sonidoDesvanecerse, volumenDesvanecerse);
            Reducir();
            tocada = true;
        }
    }

    void Reducir()
    {
       
        alpha.a = alpha.a - Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(alpha.r, alpha.g, alpha.b, alpha.a);
        if (alpha.a <= 0)
        {
            Destroy(gameObject);
        }else
        {
            Invoke("Reducir", Time.deltaTime);
        }
    }

   
}
