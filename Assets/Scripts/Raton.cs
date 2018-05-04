using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raton : MonoBehaviour {


    public static Raton instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
        instance.Iniciar();
    }
    //Lo que tenga que hacer en el start
    void Iniciar()
    {
        if (SceneManager.GetActiveScene().name == "Juego")

            Cursor.visible = false;

        else
        {
            Cursor.visible = true;
        }
    }

	

}
