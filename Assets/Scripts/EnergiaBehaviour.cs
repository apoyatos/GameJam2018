using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaBehaviour : Caer {
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Luz")
        {
            EnergyManager.instance.SumaEnergia();
            Destroy(gameObject);
        }
    }

}
