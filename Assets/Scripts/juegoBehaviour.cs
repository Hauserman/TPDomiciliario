using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class juegoBehaviour : MonoBehaviour
{
    public Text objeto1;
    public Text objeto2;
    public InputField resul;
    public GameObject panelBien;
    public GameObject panelMal;
    public GameObject panelNoResponde;
    public Producto[] productos1;
    public Producto[] productos2;

    private void Start()
    {
        resetjuego();
    }
    bool checkearSuma(int num1, int num2, int resul)
    {
        return (num1 + num2 == resul) ? true : false;
    }

    public void botonResponderActivado()
    {
        if (resul.text=="")
        {
            panelNoResponde.SetActive(true);
            return;
        }
        int resultado = Convert.ToInt32(resul.text);
        if (checkearSuma(Convert.ToInt32(objeto1.text), Convert.ToInt32(objeto2.text), resultado)){
            panelBien.SetActive(true);
        }
        else
        {
            panelMal.SetActive(true);
        }
    }
    void reiniciarPaneles()
    {
        panelNoResponde.SetActive(false);
        panelMal.SetActive(false);
        panelBien.SetActive(false);
    }

    public void resetjuego()
    {
        reiniciarPaneles();
        iniciarJuego();
    }

    public void botonSalirActivado()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void volverAIntentar()
    {
        reiniciarPaneles();
        resul.text = "";
    }

    void iniciarJuego()
    {
        Producto randProd1 = productos1[UnityEngine.Random.Range(0, productos1.Length - 1)];
        Producto randProd2 = productos2[UnityEngine.Random.Range(0, productos2.Length - 1)];
        deactivateAll();
        randProd1.gameObject.SetActive(true);
        randProd2.gameObject.SetActive(true);
        objeto1.text = randProd1.precio.ToString();
        objeto2.text = randProd2.precio.ToString();
        resul.text = "";
    }

    void deactivateAll()
    {
        foreach (Producto producto in productos1)
        {
            producto.gameObject.SetActive(false);
        }
        foreach (Producto producto in productos2)
        {
            producto.gameObject.SetActive(false);
        }
    }

}
