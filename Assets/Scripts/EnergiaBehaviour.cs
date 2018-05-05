using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaBehaviour : Caer {

    public AudioClip sonidoEnergia;
    public float volumenEnergia;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Luz")
        {
        SoundManager.instance.ReproducirSonido(sonidoEnergia, volumenEnergia).MoveNext();
        EnergyManager.instance.SumaEnergia();
        Destroy(gameObject);
        }
    }

}
