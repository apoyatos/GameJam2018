using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : ObjetosFondo {

    public Sprite[] sprites;

    public override void Iniciar()
    {
        base.Iniciar();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
