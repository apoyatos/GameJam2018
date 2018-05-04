using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    public float velocidad;
    public float fuerzaSalto;

    EnergyManager energyManager;
    Rigidbody2D rb;
    int puedeSaltar=0;//0 en tierra 1 en el aire y puede saltar 2 no puede saltar


	void Start () {
        rb = GetComponent<Rigidbody2D>();
        energyManager = FindObjectOfType<EnergyManager>();
	}
	
    void ControlJugador()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, fuerzaSalto));
            puedeSaltar += 1;
           // energyManager.RestaEnergia();
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
        }
    }
}
