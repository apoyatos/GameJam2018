using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrInstrucciones : MonoBehaviour {

	public void Ir()
    {
        SceneManager.LoadScene("Instrucciones");
    }
}
