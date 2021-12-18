using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissionTextController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI missionText;
    [SerializeField] private string sentences;
    [SerializeField] private Button startMissionButton;
    

    void Start() 
    {
        startMissionButton.gameObject.SetActive(false);
        StartCoroutine(Type());
        
            
    }


    IEnumerator Type()
    {
        foreach(char letter in sentences.ToCharArray())
        {
            missionText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        startMissionButton.gameObject.SetActive(true);
    }
}
