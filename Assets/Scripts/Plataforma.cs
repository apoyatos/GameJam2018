using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : Caer
{

    override public void Muerte()
    {
        GeneradorPlataformas.instance.EliminarPlataforma(this);
    }
}
