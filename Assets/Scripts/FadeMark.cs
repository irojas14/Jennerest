using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMark : MonoBehaviour
{
    public Animator animator;
    
    void Start() 
    {
        StartCoroutine(FadeMar());
    }
    private IEnumerator FadeMar()
    {
        animator.SetBool("Fade", false);
        yield return new WaitForSeconds(9.0f);
        animator.SetBool("Fade", true);
    }
}
