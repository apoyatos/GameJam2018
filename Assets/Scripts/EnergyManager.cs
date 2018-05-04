﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour {

    public int energiaInicial =10;

    int actual;

	void Start () {
        actual = energiaInicial;
	}


    public void RestaEnergia()
    {
        if (actual > 0)
            actual--;

        else
            GameManager.instance.FinPartida();

    }
    public void SumaEnergia()
    {
        actual++;
    }
    public int EnergiaActual()
    {
        return actual;
    }
}