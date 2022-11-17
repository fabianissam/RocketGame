using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{


    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        string collisionTag = collision.gameObject.tag;
        int index = SceneManager.GetActiveScene().buildIndex;
        switch (collisionTag)
        {
            case "Friendly":
                break;
            case "Finish":
                index = index + 1;
                if (index == SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(index);
                }
                break;
            default:
                // hinweis in die doku nachtragen
                SceneManager.LoadScene(index);
                break;

        }
    }
}
