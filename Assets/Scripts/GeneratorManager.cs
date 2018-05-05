using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour {

    void Start()
    {
        StartCoroutine(EsperarInput());
    }

    IEnumerator EsperarInput()
    {
        while (!Input.anyKey)
        {
            yield return 0;
        }
        GeneradorPlataformas.instance.GenerarPlataformas();
        for(int i =0; i<generadorObjetos.instance.Length;i++)
            generadorObjetos.instance[i].GenerarObjeto();
        yield return null;
    }
}
