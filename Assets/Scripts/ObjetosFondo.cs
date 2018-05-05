using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosFondo : Caer {

    GeneradorFondo generador;

   public void AsignarGenerador(GeneradorFondo g)
    {
        generador = g;
    }

	override public void Muerte()
    {
        generador.EliminarObjeto(this);
        Destroy(gameObject);
    }
}
