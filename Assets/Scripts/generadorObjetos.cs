using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class generadorObjetos : MonoBehaviour {

    public float tiempoDeCreacionInicial;
    public float tiempoMinimo;
    public float aceleracionTiempoPorInvocacion;
    public float velocidadInicialMedia;
    public float desviacionVelocidad;
    public float velocidadMaxima;
    public float aceleracionVelociadPorInvocacion;
    public Caer objeto;

    float limiteIzquierdo, limiteDerecho;
    ulong numeroInvocaciones;
    
	void Start () {
        numeroInvocaciones = 0;
        Bounds limites = GetComponent<BoxCollider2D>().bounds;
        limiteIzquierdo = limites.min.x;
        limiteDerecho = limites.max.x;
        Invoke("Crear", tiempoDeCreacionInicial);
	}
    void Crear()
    {
        Caer aux = Instantiate(objeto);
        float velocidadAuxiliar = Mathf.Min(velocidadInicialMedia + numeroInvocaciones * aceleracionTiempoPorInvocacion, velocidadMaxima);
        aux.velocidadCaida = Random.Range(velocidadAuxiliar -desviacionVelocidad, velocidadAuxiliar + desviacionVelocidad);
        Vector2 auxiliar = transform.position;
        auxiliar.x = Random.Range(limiteIzquierdo, limiteDerecho);
        objeto.transform.position = auxiliar;
        if (numeroInvocaciones != ulong.MaxValue)
            numeroInvocaciones++;
        Invoke("Crear", 
            Mathf.Max(tiempoMinimo, tiempoDeCreacionInicial - aceleracionTiempoPorInvocacion * numeroInvocaciones));
    }
}
