using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xd : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
     {    
        if (collision.gameObject.tag == "pelota")
        {
            gameManager.puntos++;
            Destroy(gameObject);
        }
     }

 
}
