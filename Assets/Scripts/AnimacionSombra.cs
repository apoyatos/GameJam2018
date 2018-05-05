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
        if (rb2D.velocity.y > 0.5f)
            anim.SetInteger("Direction", 1);

        else if (rb2D.velocity.y < -0.5f)
            anim.SetInteger("Direction", 2);

        else if (rb2D.velocity.x > 0.5f)
            anim.SetInteger("Direction", 3);
        else if (rb2D.velocity.x < -0.5f)
            anim.SetInteger("Direction", 4);

    }
}
