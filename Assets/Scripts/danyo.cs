using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danyo : MonoBehaviour {

    public AudioClip rocaSonido;
    public float rocaVolumen;

    IEnumerator rocaSon;

    void Start()
    {
        rocaSon = SoundManager.instance.ReproducirSonido(rocaSonido, rocaVolumen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Roca")
        {
            rocaSon.MoveNext();
            EnergyManager.instance.RestaEnergia();
            Destroy(collision.gameObject);
        }
    }
}
