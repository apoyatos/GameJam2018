using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaBehaviour : MonoBehaviour {

    Collider2D colEner;
    EnergyManager energyManager;


	void Start ()
    {
        colEner = GetComponent<Collider2D>();
	}

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "JugadorLuz")
        {
            energyManager.SumaEnergia();
            Destroy(gameObject);
        }
    }

}
