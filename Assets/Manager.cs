using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int puntos;
    public static int fin;
    public GameObject jugador;
    public GameObject Dum1, Dum2, Dum3, Dum4, Dum5, Dum6, Dum7, Dum8, Dum9, Dum10, Dum11, Dum12, Dum13, Dum14;

    void Start()
    {
        puntos = 0;
        fin = 0;
    }

    void Update()
    {
        if (puntos == 14)
        {
            Debug.Log("Tepeado");
            jugador.transform.position = new Vector3(0, 0, 0);
            fin = 1;
            puntos = 0;
        }

        if (fin == 1)
        {
            Dum1.SetActive(true);
            Dum2.SetActive(true);
            Dum3.SetActive(true);
            Dum4.SetActive(true);
            Dum5.SetActive(true);
            Dum6.SetActive(true);
            Dum7.SetActive(true);
            Dum8.SetActive(true);
            Dum9.SetActive(true);
            Dum10.SetActive(true);
            Dum11.SetActive(true);
            Dum12.SetActive(true);
            Dum13.SetActive(true);
            Dum14.SetActive(true);

            fin = 0;
        }
    }
}
