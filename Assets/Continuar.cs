using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuar : MonoBehaviour {

    public void Apretar()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        transform.parent.gameObject.SetActive(false);
    }
}
