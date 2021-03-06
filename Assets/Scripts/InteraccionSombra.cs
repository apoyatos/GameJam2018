﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionSombra : MonoBehaviour
{

    bool dentro;
    GameObject roca;
    public AudioClip rocaSonido;
    public float rocaVolumen;
    public AudioClip sombraSonido;
    public float sombraVolumen;

    IEnumerator rocaSon;
    IEnumerator SombraSon;

    void Start()
    {
        rocaSon = SoundManager.instance.ReproducirSonido(rocaSonido, rocaVolumen);
        SombraSon = SoundManager.instance.ReproducirSonido(sombraSonido, sombraVolumen);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnergyManager.instance.AtaqueSombra();
            SombraSon.MoveNext();
            if (dentro)
            {
                roca.GetComponent<RocaBehaviour>().Destruir();
                rocaSon.MoveNext();
                GameManager.instance.SumaPuntos(GameManager.instance.puntosPorDestruirRocas);

            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Roca") && !dentro)
        {
            roca = col.gameObject;
            dentro = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Roca"))
        {
            roca = null;
            dentro = false;
        }
    }

}
