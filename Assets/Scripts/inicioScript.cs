using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicioScript : MonoBehaviour
{
    public void irASuma()
    {
        SceneManager.LoadScene("juegoSuma");
    }
}
