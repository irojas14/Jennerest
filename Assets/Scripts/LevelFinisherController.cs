using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisherController : MonoBehaviour
{

    private bool isPlayerTouchingMe = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerTouchingMe == true && SceneManager.GetActiveScene().name != "Tutorial")
            {
                SceneManager.LoadScene("WinScene");
            }

            else if(isPlayerTouchingMe == true && SceneManager.GetActiveScene().name == "Tutorial")
            {
                SceneManager.LoadScene("LoadAlphaLevel");
            }
        }
    }

    // Importante que las puertas tengan el tag "Teleporter"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerTouchingMe = true;
        }
    }
}
