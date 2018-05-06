using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionSombra : MonoBehaviour {

    const float MARGEN = 1f;

    Animator anim;
    Rigidbody2D rb2D;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Ataque");
        }
        else
        {
            if (rb2D.velocity.y > MARGEN && Mathf.Abs(rb2D.velocity.x) < rb2D.velocity.y)
                anim.SetTrigger("Arriba");

            else if (rb2D.velocity.y < -MARGEN && Mathf.Abs(rb2D.velocity.x) < -rb2D.velocity.y)
                anim.SetTrigger("Abajo");
            else if (rb2D.velocity.x > MARGEN && Mathf.Abs(rb2D.velocity.y) < rb2D.velocity.x)
                anim.SetTrigger("Derecha");
            else if (rb2D.velocity.x < -MARGEN && Mathf.Abs(rb2D.velocity.y) < -rb2D.velocity.x)
                anim.SetTrigger("Izquierda");
            else //if (rb2D.velocity.x < MARGEN && rb2D.velocity.x > -MARGEN && rb2D.velocity.y < MARGEN && rb2D.velocity.y > -MARGEN)
                anim.SetTrigger("Idle");
        }

    }
}
