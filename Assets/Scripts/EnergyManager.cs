using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

    public static EnergyManager instance;

    public int energiaInicial =10;

    Slider barraEnergia;
   public  int actual;

	void Start () {
        instance = this;
        actual = energiaInicial;
        barraEnergia = FindObjectOfType<Slider>();
        barraEnergia.maxValue = energiaInicial;
	}

    public void AtaqueSombra()
    {
        if (actual > 0)
            actual--;

        else
            GameManager.instance.FinPartida();
    }
    public void RestaEnergia()
    {
        if (actual > 0)
            actual-=5;

        else
            GameManager.instance.FinPartida();

    }
    public void SumaEnergia()
    {
        actual+=5;
    }
    public int EnergiaActual()
    {
        return actual;
    }

    private void Update()
    {
        barraEnergia.value = actual;
    }


}
