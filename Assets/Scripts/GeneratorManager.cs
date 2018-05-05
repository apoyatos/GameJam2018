using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour {

    void Start()
    {
        GeneradorPlataformas.instance.Inicio();
        
        GeneradorPlataformas.instance.GenerarPlataformasInicio();
        
        for(int i = 0; i<GeneradorFondo.instance.Length;i++)
        {
            GeneradorFondo.instance[i].Inicio();
            GeneradorFondo.instance[i].GenerarObjetosInicio();
        }
        for (int i = 0; i < generadorObjetos.instance.Length; i++)
        {
            generadorObjetos.instance[i].Inicio();
        }
        StartCoroutine(EsperarInput());
    }

    IEnumerator EsperarInput()
    {
        while (!Input.anyKey)
        {
            yield return 0;
        }
        GeneradorPlataformas.instance.GenerarPlataformas();
        for (int i = 0; i < GeneradorFondo.instance.Length; i++)
        {
            GeneradorFondo.instance[i].GenerarObjetos();
        }
        for (int i =0; i<generadorObjetos.instance.Length;i++)
            generadorObjetos.instance[i].GenerarObjeto();
        yield return null;
    }
}
