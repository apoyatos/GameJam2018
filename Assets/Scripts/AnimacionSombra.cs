using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionSombra : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb2D;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb2D.velocity.y > 0.5f && rb2D.velocity.x < 0.5 && rb2D.velocity.x > -0.5)
            anim.SetTrigger("Arriba");

        else if (rb2D.velocity.y < -0.5f && rb2D.velocity.x < 0.5 && rb2D.velocity.x > -0.5)
            anim.SetTrigger("Abajo");

        else if (rb2D.velocity.x > 0.5f)
            anim.SetTrigger("Derecha");
        else if (rb2D.velocity.x < -0.5f)
            anim.SetTrigger("Izquierda");
        else if (rb2D.velocity.x < 0.1 && rb2D.velocity.x > -0.1 && rb2D.velocity.y < 0.1 && rb2D.velocity.y > -0.1)
            anim.SetTrigger("Idle");
        print(rb2D.velocity.x + " " + rb2D.velocity.y);

    }
}
