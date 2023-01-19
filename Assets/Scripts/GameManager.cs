using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int puntos;
    public int puntosMx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if (puntos == puntosMx)
        {
            SceneManager.GetActiveScene();
            SceneManager.LoadScene("Zona_Juego");
        }
    }
}
