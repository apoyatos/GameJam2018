using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZonaMuerte : MonoBehaviour {

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ObjetoEscena aux;
        if ((aux=collision.GetComponent<ObjetoEscena>()) != null)
        {
            aux.Muerte();
        }
    }
}
