using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Spawn; // Array de prefabs (esfera, cubo, triángulo)
    public GameObject PanCampoVacio;
    public GameObject PanRespuesta;
    public InputField InfNum;

    public int minObjects = 5;
    public int maxObjects = 10;
    int cantTotal = 0;
    bool juegoFrenado = false;
    void Start()
    {
        InvokeRepeating(nameof(SpawnObjects), 0, 6f);
    }

    void Update()
    {
        if (juegoFrenado)
        {
            CancelInvoke();
        }
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
                PanRespuesta.SetActive(true);
                juegoFrenado = true;
            }
            else
            {
                print("Mal");
            }
        }
    }
    public void OnAceptarClick()
    {
        PanCampoVacio.SetActive(false);
        juegoFrenado = false;   
        InvokeRepeating(nameof(SpawnObjects), 0, 10f);
    }

    void SpawnObjects()
    {
        int objectCant = Random.Range(minObjects, maxObjects + 1);
        cantTotal += objectCant;
        int randomObject = Random.Range(0, Spawn.Length);
        for (int i = 0; i < objectCant; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 20, Random.Range(-1, 5));
            GameObject spawnedObject = Instantiate(Spawn[randomObject], spawnPosition, Quaternion.identity);
            Renderer renderer = spawnedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
}