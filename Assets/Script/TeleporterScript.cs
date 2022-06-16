using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{

    public bool isPrevAllowed = true;
    public FloatSO ScoreSO;
    

    void OnCollisionEnter2D(Collision2D Collision)
    {
        
        if (Collision.gameObject.CompareTag("TeleporterIn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Collision.gameObject.CompareTag("EndGame"))
        {
            SceneManager.LoadScene ("Ending1");
        }
    }
}
