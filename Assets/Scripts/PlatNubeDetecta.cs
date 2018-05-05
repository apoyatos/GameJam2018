using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatNubeDetecta: MonoBehaviour {

    public Collider2D colisionPlataforma;

    bool Atravesado;
    Collider2D colisionActivacol;

	void Start ()
    {
        
        colisionActivacol = GetComponent<Collider2D>();
        colisionPlataforma.enabled = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Luz")
        {
            colisionPlataforma.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Luz")
        {
            colisionPlataforma.enabled = true;
        }
    }

  
    

    

    

    
}
