using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : ObjetoEscena {

    public float velocidad;
    public float fuerzaSalto;
    public AudioClip sonidoSalto;
    public float volumenSalto;

    Rigidbody2D rb;
    int puedeSaltar=0;//0 en tierra 1 en el aire y puede saltar 2 no puede saltar
    Animator animaciones;
    IEnumerator sonSalto;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animaciones = GetComponent<Animator>();
        sonSalto = SoundManager.instance.ReproducirSonido(sonidoSalto, volumenSalto);
    }
	
    void ControlJugador()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);
        animaciones.SetFloat("x", rb.velocity.x);
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar < 2)
        {
            sonSalto.MoveNext();
            animaciones.SetBool("salto", true);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, fuerzaSalto));
            puedeSaltar += 1;
            EnergyManager.instance.RestaEnergia();
        }
        
    }

	// Update is called once per frame
	void Update () {
        ControlJugador();
	}

    private void OnCollisionEnter2D(Collision2D collision)
        
    {
        
        if (collision.collider.gameObject.CompareTag("Suelo")&& transform.position.y - collision.collider.transform.position.y >= 0)
        {            
            puedeSaltar = 0;
            animaciones.SetBool("salto", false);
        }
    }
    public override void Muerte()
    {
        Destroy(gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Sombra"));
        GameManager.instance.FinPartida();
    }
}
