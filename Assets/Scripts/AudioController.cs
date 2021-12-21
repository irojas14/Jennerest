using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource ost;
    // Start is called before the first frame update

    private void Start() 
    {
        Play_ost();    
    }
    public void Play_ost()
    {
        ost.Play();
    }
}
