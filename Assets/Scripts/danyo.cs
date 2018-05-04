using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danyo : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Roca")
        {

            EnergyManager.instance.RestaEnergia();
            Destroy(collision.gameObject);
        }
    }
}
