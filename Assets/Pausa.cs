using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

	void Start()
    {
        funcionVacia a = () =>
        {
            Cursor.visible = true;
            Time.timeScale = 0.0f;
            gameObject.SetActive(true);
        };
        GameManager.instance.Pausa += a;
        gameObject.SetActive(false);
    }
}
