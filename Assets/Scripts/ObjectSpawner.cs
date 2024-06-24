using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Spawn; // Array de prefabs (esfera, cubo, triángulo)
    public int minObjects = 5;
    public int maxObjects = 10;
    int cantTotal;
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
    void SpawnObjects()
    {
        int objectCant = Random.Range(minObjects, maxObjects + 1);
        cantTotal += objectCant;
        int randomObject = Random.Range(0, Spawn.Length);
        for (int i = 0; i < objectCant; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 20, Random.Range(-1, 5));
            Instantiate(Spawn[randomObject], spawnPosition, Quaternion.identity);
        }
    }
}