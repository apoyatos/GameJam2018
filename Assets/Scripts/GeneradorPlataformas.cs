using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformas : MonoBehaviour {


    public static GeneradorPlataformas instance;

    public float probabilidadNube;
    public float tiempoDeCreacionInicial;
    public float tiempoMinimo;
    public float porcentajeHastaAlcanzarElNumeroDeInvoaciones;
    public int numeroDeInvocacionesHastaAlcanzarElPorcentaje;
    public float distanciaEntrePlataformas;
    public Plataforma suelo;
    public Plataforma nube;

    Vector2[] posiciones;
    ulong numeroInvocaciones;
    List<Plataforma> todasLasPlataformas;
    float tiempo;

    void Awake()
    {

        instance = this;
    }

    // Use this for initialization
    public void Inicio()
    {
        posiciones = new Vector2[3];
        numeroInvocaciones = 0;
        float limiteIzquierdo = Camera.main.ViewportToWorldPoint(Camera.main.rect.min).x;
        float diferenciaLimite = Camera.main.ViewportToWorldPoint(Camera.main.rect.max).x - limiteIzquierdo;
        GameObject obj = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo).gameObject;
        Bounds col = obj.GetComponent<Collider2D>().bounds;
        for (int i = 0; i<3; i++)
        {
            posiciones[i] = Camera.main.ViewportToWorldPoint(Camera.main.rect.max);
            posiciones[i].x = limiteIzquierdo + diferenciaLimite / 6f * (1 + i * 2);
            posiciones[i].y += col.size.y/2f;
        }  
        Destroy(obj);
        todasLasPlataformas = new List<Plataforma>();        
    }
	
    

	public void GenerarPlataformas()
    {
        Plataforma aux1, aux2=null;
        switch (Random.Range(0, 5))
        {
            case 0:
                aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[0], Quaternion.identity);
                break;
            case 1:
                aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[1], Quaternion.identity);
                break;
            case 2:
                aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[2], Quaternion.identity);
                break;
            case 3:
                aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[0], Quaternion.identity);
                aux2 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[1], Quaternion.identity);
                break;
            case 4:
                aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[0], Quaternion.identity);
                aux2 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[2], Quaternion.identity);
                break;
            default:
                aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[1], Quaternion.identity);
                aux2 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[2], Quaternion.identity);
                break;
        }
        todasLasPlataformas.Add(aux1);

        if(aux2!=null)
        {
            todasLasPlataformas.Add(aux2);
        }
        tiempo = tiempoMinimo + (tiempoDeCreacionInicial - tiempoMinimo) * Mathf.Exp(Mathf.Log(1f-porcentajeHastaAlcanzarElNumeroDeInvoaciones)/numeroDeInvocacionesHastaAlcanzarElPorcentaje*numeroInvocaciones);
        float velocidad = distanciaEntrePlataformas / tiempo;

        foreach (Plataforma item in todasLasPlataformas)
        {
            item.cambiarVelocidad(velocidad);
        }

        Invoke("GenerarPlataformas", tiempo);
        numeroInvocaciones++;
    }

    public void GenerarPlataformasInicio()
    {
        Vector2 vectorAbajo = Vector2.down * distanciaEntrePlataformas;
        int i = 1;
        float distanciaMaxima = Camera.main.ViewportToWorldPoint(Camera.main.rect.max).y - Camera.main.ViewportToWorldPoint(Camera.main.rect.min).y;
        while (distanciaEntrePlataformas*i<distanciaMaxima-distanciaEntrePlataformas)
        {
            Plataforma aux1, aux2 = null;

            switch (Random.Range(0, 5))
            {
                case 0:
                    aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[0]+vectorAbajo*i, Quaternion.identity);
                    break;
                case 1:
                    aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[1] + vectorAbajo * i, Quaternion.identity);
                    break;
                case 2:
                    aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[2] + vectorAbajo * i, Quaternion.identity);
                    break;
                case 3:
                    aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[0] + vectorAbajo * i, Quaternion.identity);
                    aux2 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[1] + vectorAbajo * i, Quaternion.identity);
                    break;
                case 4:
                    aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[0] + vectorAbajo * i, Quaternion.identity);
                    aux2 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[2] + vectorAbajo * i, Quaternion.identity);
                    break;
                default:
                    aux1 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[1] + vectorAbajo * i, Quaternion.identity);
                    aux2 = Instantiate(Random.Range(0f, 1f) < probabilidadNube ? nube : suelo, posiciones[2] + vectorAbajo * i, Quaternion.identity);
                    break;
            }

            todasLasPlataformas.Add(aux1);

            if (aux2 != null)
            {
                todasLasPlataformas.Add(aux2);
            }
            i++;
        }

        todasLasPlataformas.Add(Instantiate(suelo, posiciones[1] + vectorAbajo * i, Quaternion.identity));

        //posicionar al jugador
        Transform jugador = GameObject.FindGameObjectWithTag("Luz").transform;
        jugador.position = posiciones[1] + vectorAbajo * i + Vector2.down*(jugador.GetComponent<Collider2D>().bounds.min.y - jugador.GetComponent<Collider2D>().bounds.max.y);

        foreach (Plataforma item in todasLasPlataformas)
        {
            item.cambiarVelocidad(0f);
        }

    }
    public float Tiempo()
    {
        return tiempo;
    }

    public void EliminarPlataforma(Plataforma plataforma)
    {
        todasLasPlataformas.Remove(plataforma);
        Destroy(plataforma.gameObject);
    }
}
