using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatNubeDetecta: MonoBehaviour {

    bool Atravesado;
    Collider2D colisionPlataforma;
    Collider2D colisionActivacol;

	void Start ()
    {
        colisionPlataforma = GetComponentInParent<Collider2D>();
        colisionActivacol = GetComponent<Collider2D>();
        colisionPlataforma.enabled = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "JugadorLuz")
        {
            colisionPlataforma.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "JugadorLuz")
        {
            colisionPlataforma.enabled = true;
        }
    }

  
    

    

    

    
}
