using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaBehaviour : MonoBehaviour {

    ParticleSystem part;

	void Start ()
    {
        part = GetComponent<ParticleSystem>();
        part.Pause();
	}
	
	
	public void Destruir ()
    {
        part.Play();
        Destroy(gameObject, part.time);
        GetComponent<Collider2D>().enabled = false;
	}
}
