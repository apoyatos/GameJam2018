using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorObjetos : MonoBehaviour {

    static public generadorObjetos[] instance;

    public float porcentajeDesviacionVelocidad;
    public float porcentajeDesviacionTiempo;
    public float multiplicadorFrecuencia;
    public Caer objeto;

    float limiteIzquierdo, limiteDerecho;
    Vector2 posicionSuperior;
    
	void Awake () {
        instance = GameObject.FindObjectsOfType<generadorObjetos>();
	}

    public void Inicio()
    {
        Collider2D limites = Instantiate(objeto).GetComponent<Collider2D>();
        limiteIzquierdo = Camera.main.ViewportToWorldPoint(Camera.main.rect.min).x + limites.bounds.size.x;
        limiteDerecho = Camera.main.ViewportToWorldPoint(Camera.main.rect.max).x - limites.bounds.size.x;
        posicionSuperior = Camera.main.ViewportToWorldPoint(Camera.main.rect.max);
        posicionSuperior.y += limites.bounds.size.y;
        Destroy(limites.gameObject);
    }

    public void GenerarObjeto()
    {
        Caer aux = Instantiate(objeto);
        float velocidadAuxiliar = GeneradorPlataformas.instance.distanciaEntrePlataformas/GeneradorPlataformas.instance.Tiempo()*Random.Range(1f-porcentajeDesviacionVelocidad,1f+porcentajeDesviacionVelocidad);
        aux.cambiarVelocidad(velocidadAuxiliar);
        Vector2 auxiliar = posicionSuperior;
        auxiliar.x = Random.Range(limiteIzquierdo, limiteDerecho);
        objeto.transform.position = auxiliar;
        Invoke("GenerarObjeto", 
            GeneradorPlataformas.instance.Tiempo()/multiplicadorFrecuencia*Random.Range(1f-porcentajeDesviacionTiempo,1f+porcentajeDesviacionTiempo));
    }
}
