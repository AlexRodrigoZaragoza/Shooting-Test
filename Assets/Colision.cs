using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(true);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bola")
        {
            Manager.puntos++;
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            Debug.Log("Hited");


        }
    }

}
