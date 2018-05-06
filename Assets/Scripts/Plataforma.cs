using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FormaPlataforma
{
    abiertaPorLaIzquierda, abiertaPorLaDerecha, abiertaPorAmbosLados, cerradaPorAmbosLados
}

public class Plataforma : MonoBehaviour
{
    public Sprite abiertaPorLaIzquierda, abiertaPorLaDerecha, abiertaPorAmbosLados, cerradaPorAmbosLados;
    SpriteRenderer sprite;
    Caer caida;

    void Awake()
    {
        caida = GetComponent<Caer>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void CambiarSprite(FormaPlataforma forma)
    {
        switch(forma)
        {
            case FormaPlataforma.abiertaPorLaIzquierda:
                sprite.sprite = abiertaPorLaIzquierda;
                break;
            case FormaPlataforma.abiertaPorLaDerecha:
                sprite.sprite = abiertaPorLaDerecha;
                break;
            case FormaPlataforma.abiertaPorAmbosLados:
                sprite.sprite = abiertaPorAmbosLados;
                break;
            case FormaPlataforma.cerradaPorAmbosLados:
                sprite.sprite = cerradaPorAmbosLados;
                break;
        }
    }

    public void Muerte()
    {
        GeneradorPlataformas.instance.EliminarPlataforma(this);
    }
    public void cambiarVelocidad(float velocidad)
    {
        caida.cambiarVelocidad(velocidad);
    }
}
