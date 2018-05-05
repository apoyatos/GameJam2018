using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFondo : MonoBehaviour {

    static public GeneradorFondo[] instance;

    public float numeroDeObejetosEntrePlataformas;
    public int numeroMaximoDeObjetosPorFila;
    public ObjetosFondo objeto;

    float limiteIzquierdo, limiteDerecho;
    Vector2 posicionSuperior;
    List<ObjetosFondo> todosLosElementosFondo;
    float abajo;

    void Awake()
    {
        instance = GameObject.FindObjectsOfType<GeneradorFondo>();
    }

    public void Inicio()
    {
        abajo = GeneradorPlataformas.instance.distanciaEntrePlataformas / numeroDeObejetosEntrePlataformas;
        Collider2D limites = Instantiate(objeto).GetComponent<Collider2D>();
        limiteIzquierdo = Camera.main.ViewportToWorldPoint(Camera.main.rect.min).x + limites.bounds.size.x;
        limiteDerecho = Camera.main.ViewportToWorldPoint(Camera.main.rect.max).x - limites.bounds.size.x;
        posicionSuperior = Camera.main.ViewportToWorldPoint(Camera.main.rect.max);
        posicionSuperior.y += limites.bounds.size.y;
        posicionSuperior.x = Camera.main.ViewportToWorldPoint(Camera.main.rect.min).x;
        Destroy(limites.gameObject);
        todosLosElementosFondo = new List<ObjetosFondo>();
    }
    public void GenerarObjetos()
    {
        float distanciaMaxima = Camera.main.ViewportToWorldPoint(Camera.main.rect.max).y - Camera.main.ViewportToWorldPoint(Camera.main.rect.min).y;
        int i = 1;
        
        GenerarEnAltura(posicionSuperior, Random.Range(0, numeroMaximoDeObjetosPorFila));
            

        float velocidadAuxiliar = GeneradorPlataformas.instance.distanciaEntrePlataformas / GeneradorPlataformas.instance.Tiempo() ;

        foreach (ObjetosFondo item in todosLosElementosFondo)
        {
            item.cambiarVelocidad(velocidadAuxiliar);
        }

        Invoke("GenerarObjetos",
            GeneradorPlataformas.instance.Tiempo() / numeroDeObejetosEntrePlataformas);
    }
     public void GenerarObjetosInicio()
    {
        int i = 1;
        float distanciaMaxima = Camera.main.ViewportToWorldPoint(Camera.main.rect.max).y - Camera.main.ViewportToWorldPoint(Camera.main.rect.min).y;
        while (abajo * i < distanciaMaxima)
        {
            GenerarEnAlturaInicio(posicionSuperior + i * Vector2.down * (abajo), Random.Range(0, numeroMaximoDeObjetosPorFila));
            i++;
        }
    }
    void GenerarEnAlturaInicio(Vector2 altura, int n)
    {
        for(int i = 0; i <n; i++)
        {
            ObjetosFondo aux = Instantiate(objeto, new Vector2(Random.Range(0f, limiteDerecho-limiteIzquierdo), Random.Range(0f, GeneradorPlataformas.instance.distanciaEntrePlataformas)) + altura, Quaternion.identity);
            todosLosElementosFondo.Add(aux);
            aux.AsignarGenerador(this);
        }
    }
    void GenerarEnAltura(Vector2 altura, int n)
    {
        for (int i = 0; i < n; i++)
        {
            ObjetosFondo aux = Instantiate(objeto, new Vector2(Random.Range(0f, limiteDerecho - limiteIzquierdo), Random.Range(0f, GeneradorPlataformas.instance.distanciaEntrePlataformas)) + altura, Quaternion.identity);
            todosLosElementosFondo.Add(aux);
            aux.AsignarGenerador(this);
        }
    }

    public void EliminarObjeto(ObjetosFondo objeto)
    {
        todosLosElementosFondo.Remove(objeto);
    }
}
