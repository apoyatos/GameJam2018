using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatNube : MonoBehaviour {


    
    public float tempDestruccion = 3f;

    SpriteRenderer sprt;
    Color alpha;

	// Use this for initialization
	void Start ()
    {
        alpha = sprt.GetComponent<SpriteRenderer>().color;
        sprt = GetComponent<SpriteRenderer>();
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "JugadorLuz")
        {
            Reducir();
        }
    }

    void Reducir()
    {
        
        alpha.a--;

        if(alpha.a <= 0)
        {
            Destroy(gameObject);
        }else
        {
            Invoke("Reducir", tempDestruccion / 255);
        }
    }

   
}
