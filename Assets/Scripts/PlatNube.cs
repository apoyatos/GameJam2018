using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatNube : MonoBehaviour {
    
    public float tempDestruccion = 3f;
    public float velocidadDesvanecimiento;
    public AudioClip sonidoDesvanecerse;
    public float volumenDesvanecerse;

    bool tocada = false;
    SpriteRenderer sprite;
    GameObject jugador;
    PlatformEffector2D plataforma;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        plataforma = GetComponent<PlatformEffector2D>();
        Collider2D col = GetComponent<Collider2D>();
        plataforma.surfaceArc = 180f - 2f * Mathf.Atan(col.bounds.size.y / (col.bounds.size.x));

    }

   void OnTriggerEnter2D(Collider2D col)
    {
        if(!tocada && col.tag == "Luz")
        {
            jugador = col.gameObject;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == jugador)
        {
            SoundManager.instance.ReproducirSonido(sonidoDesvanecerse, volumenDesvanecerse).MoveNext();
            Reducir();
            tocada = true;
        }
    }

    void Reducir()
    {
        Color color = sprite.color;
        color.a -= Time.deltaTime * velocidadDesvanecimiento;
        sprite.color = color;
        if (color.a <= 0)
        {
            Destroy(gameObject);
        }else
        {
            Invoke("Reducir", Time.deltaTime);
        }
    }

   
}
