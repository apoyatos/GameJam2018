using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformas : MonoBehaviour {


    public static GeneradorPlataformas instance;

    public float tiempoDeCreacionInicial;
    public float tiempoMinimo;
    public float aceleracionTiempoPorInvocacion;
    public float velocidadInicial;
    public float aceleracionVelocidadPorInvocacion;
    public float velocidadMaxima;
    public Plataforma objeto;

    Vector2[] posiciones;
    ulong numeroInvocaciones;
    List<Plataforma> todasLasPlataformas;

    // Use this for initialization
    void Start () {
        instance = this;
        posiciones = new Vector2[3];
        numeroInvocaciones = 0;
        Bounds limites = GetComponent<BoxCollider2D>().bounds;
        float limiteIzquierdo = limites.min.x;
        float diferenciaLimite = limites.max.x - limiteIzquierdo;
        for(int i = 0; i<3; i++)
        {
            posiciones[i] = transform.position;
            posiciones[i].x = limiteIzquierdo + diferenciaLimite / 6f * (1 + i * 2);
        }
        todasLasPlataformas = new List<Plataforma>();
        GenerarPlataformas();
    }
	
	void GenerarPlataformas()
    {
        Plataforma aux1, aux2=null;
        switch (Random.Range(0, 5))
        {
            case 0:
                aux1 = Instantiate(objeto,posiciones[0],Quaternion.identity);
                break;
            case 1:
                aux1 = Instantiate(objeto, posiciones[1], Quaternion.identity);
                break;
            case 2:
                aux1 = Instantiate(objeto, posiciones[2], Quaternion.identity);
                break;
            case 3:
                aux1 = Instantiate(objeto, posiciones[0], Quaternion.identity);
                aux2 = Instantiate(objeto, posiciones[1], Quaternion.identity);
                break;
            case 4:
                aux1 = Instantiate(objeto, posiciones[0], Quaternion.identity);
                aux2 = Instantiate(objeto, posiciones[2], Quaternion.identity);
                break;
            default:
                aux1 = Instantiate(objeto, posiciones[1], Quaternion.identity);
                aux2 = Instantiate(objeto, posiciones[2], Quaternion.identity);
                break;
        }
        todasLasPlataformas.Add(aux1);

        if(aux2!=null)
        {
            todasLasPlataformas.Add(aux2);
        }

        float velocidad = Mathf.Min(velocidadInicial + aceleracionVelocidadPorInvocacion * numeroInvocaciones,velocidadMaxima);
        foreach (Plataforma item in todasLasPlataformas)
        {
            item.velocidadCaida = velocidad;
        }

        Invoke("GenerarPlataformas", Mathf.Max(tiempoDeCreacionInicial - numeroInvocaciones * aceleracionTiempoPorInvocacion, tiempoMinimo));
        numeroInvocaciones++;
    }

    public void EliminarPlataforma(Plataforma plataforma)
    {
        todasLasPlataformas.Remove(plataforma);
        Destroy(plataforma.gameObject);
    }
}
