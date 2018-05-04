using System.Collections;
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
        actual--;
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
