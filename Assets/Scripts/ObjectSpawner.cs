using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Spawn; // Array de prefabs (esfera, cubo, triángulo)
    public GameObject PanCampoVacio;
    public GameObject PanRespuesta;
    public InputField InfNum;
    public Text TXTRespuesta;
    public Text repetir;
    public float intervalo;


    public int minObjects = 5;
    public int maxObjects = 10;
    int cantTotal = 0;
    bool juegoFrenado = false;
    void Start()
    {
        InvokeRepeating(nameof(SpawnObjects), 0, intervalo);
    }
    void Update()
    {
        if (juegoFrenado)
        {
            CancelInvoke();
        }
    }

    public void OnRepetirClick()
    {
        juegoFrenado = false;
        PanRespuesta.SetActive(false);
        InvokeRepeating(nameof(SpawnObjects), 0, intervalo);
    }

    public void OnSalirClick()
    {
        SceneManager.LoadScene("SeleccionarJuegos");
    }

    public void OnResponderClick()
    {
        if (InfNum.text == "")
        {
            PanCampoVacio.SetActive(true);
            juegoFrenado = true;
        }
        else
        {
            if (InfNum.text == cantTotal.ToString())
            {
                TXTRespuesta.text = "Resultado correcto";
                repetir.text = "Reiniciar el desafío";
                juegoFrenado = true;
                PanRespuesta.SetActive(true);
            }
            else
            {
                TXTRespuesta.text = "Resultado incorrecto";
                repetir.text = "Volver a intentarlo";
                juegoFrenado = true;
                PanRespuesta.SetActive(true);
            }
        }
    }
    public void OnAceptarClick()
    {
        PanCampoVacio.SetActive(false);
        juegoFrenado = false;   
        InvokeRepeating(nameof(SpawnObjects), 0, intervalo);
    }

    void SpawnObjects()
    {
        int objectCant = Random.Range(minObjects, maxObjects + 1);
        cantTotal += objectCant;
        int randomObject = Random.Range(0, Spawn.Length);
        randomObject = 1;
        for (int i = 0; i < objectCant; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-6, 3), 16, Random.Range(-3, 5));
            GameObject spawnedObject = Instantiate(Spawn[randomObject], spawnPosition, Quaternion.identity);
            Renderer renderer = spawnedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
}