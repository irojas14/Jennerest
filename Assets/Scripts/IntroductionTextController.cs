using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroductionTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI introductionText;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private string[] sentences;
    [SerializeField] private Button startMissionButton;
    private int index;
    

    void Start() 
    {
        startMissionButton.gameObject.SetActive(false);
        StartCoroutine(Type());
    }


    void Update() 
    {
        if(index == sentences.Length - 1)
        {
            startMissionButton.gameObject.SetActive(true);
            continueText.enabled = false;
        }
    }


    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            introductionText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            introductionText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            introductionText.text = "";
        }
            
    }
}
