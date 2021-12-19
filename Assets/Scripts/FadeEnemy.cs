using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEnemy : MonoBehaviour
{
    public Animator animator;
    
    void Start() 
    {
        StartCoroutine(FadeEnem());
    }
    private IEnumerator FadeEnem()
    {
        animator.SetBool("Fade", false);
        yield return new WaitForSeconds(8.0f);
        animator.SetBool("Fade", true);
    }
}
    
