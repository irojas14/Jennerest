using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisherController : MonoBehaviour
{

    private bool isPlayerTouchingMe = false;
    public GameObject otherObject;
    Animator otherAnimator;
    string new_Scene;
    void Awake ()
    {
         otherAnimator = otherObject.GetComponent<Animator> ();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (isPlayerTouchingMe == true && SceneManager.GetActiveScene().name == "AlphaLevel")
            {
                new_Scene ="LoadAlphaLevel2";
                StartCoroutine(Fade());
         
               // SceneManager.LoadScene("LoadAlphaLevel2");
            }

            else if(isPlayerTouchingMe == true && SceneManager.GetActiveScene().name == "AlphaLevel2")
            {
                new_Scene ="WinScene";
                StartCoroutine(Fade());
               
                //SceneManager.LoadScene("WinScene");
            }

            else if(isPlayerTouchingMe == true && SceneManager.GetActiveScene().name == "Tutorial")
            {
                new_Scene = "LoadAlphaLevel";
                StartCoroutine(Fade());
                //SceneManager.LoadScene("LoadAlphaLevel");
            }

            
        
        }
    }
    private IEnumerator Fade()
    {

        otherAnimator.SetBool("Trigger",true) ;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(new_Scene);

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
