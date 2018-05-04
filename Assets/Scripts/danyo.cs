using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danyo : MonoBehaviour {
    EnergyManager energyManager;
    private void Start()
    {
        energyManager = FindObjectOfType<EnergyManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Roca")
            energyManager.RestaEnergia();
    }
}
