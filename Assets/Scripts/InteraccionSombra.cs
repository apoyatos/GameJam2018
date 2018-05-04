using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionSombra : MonoBehaviour {

    bool dentro;
    GameObject roca;
    EnergyManager sombra;
   
    void Start()
    {
        sombra = GameObject.FindWithTag("IndicadorEnergia").GetComponent<EnergyManager>();
    }

	void Update () {
        if (Input.GetMouseButtonDown(0) && dentro)
        {
            sombra.RestaEnergia();
            Destroy(roca);
            GameManager.instance.SumaPuntos();
        }
        else if(Input.GetMouseButtonDown(0))
            sombra.RestaEnergia();
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
