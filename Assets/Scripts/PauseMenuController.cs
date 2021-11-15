using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        isPaused = false;        
    }

    
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            openModal();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            closeModal();
        }
    }


    public void openModal()
    {
        isPaused = true;
        Debug.Log("Pausado.");
        PauseMenu.SetActive(true);
        PauseGame();
    }

    public void closeModal()
    {
        isPaused = false;
        Debug.Log("Juegue.");
        PauseMenu.SetActive(false);
        ResumeGame();
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }


}


