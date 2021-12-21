using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroductionTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI introductionText;
    [SerializeField] private string[] sentences;
    [SerializeField] private Button startMissionButton;
    [SerializeField] private GameObject continueButton;
    private int index;
    

    void Start() 
    {
        startMissionButton.gameObject.SetActive(false);
        StartCoroutine(Type());
    }


    void Update() 
    {

        if(introductionText.text == sentences[index] && index != sentences.Length - 1)
        {
            continueButton.SetActive(true);
        }


        if(index == sentences.Length - 1)
        {
            startMissionButton.gameObject.SetActive(true);
        }
    }


    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            introductionText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void NextSentence()
    {

        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            introductionText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            introductionText.text = "";
            continueButton.SetActive(false);
        }
            
    }
}
