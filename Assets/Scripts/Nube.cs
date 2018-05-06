using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : ObjetosFondo {

    public Sprite[] imagenes;
    public float alpha;
    public float minimoRojo, maximoRojo, minimoVerde, maximoVerde, minimoAzul, maximoAzul; 

    public override void Iniciar()
    {
        base.Iniciar();
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        render.sprite = imagenes[Random.Range(0, imagenes.Length - 1)];
        Color color;
        color.a = alpha;
        color.r = Random.Range(minimoRojo, maximoRojo);
        color.g = Random.Range(minimoVerde, maximoVerde);
        color.b = Random.Range(minimoAzul, maximoAzul);
        render.color = color;
        render.sortingOrder = -5;
    }
}
