using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatNube : Plataforma {


    
    public float tempDestruccion = 3f;
    Color platColor;
    
    public Color alpha;

	// Use this for initialization
	void Start ()
    {
        alpha = GetComponent<SpriteRenderer>().color;
        alpha.a = 1;
        
        
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Luz")
        {
            Reducir();
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
