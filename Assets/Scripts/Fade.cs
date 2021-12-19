using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour 
{
    public float num;
    public bool fade = false;
    Image img;
    float speed;
 
    void Start() 
    {
        img = GetComponent<Image>();
        StartCoroutine(Faderev());
    }
 
    void FadeOutImage(float _speed) 
    {
        speed = _speed;
        fade = true;
    }
 
    void Update() 
    {
        if(fade)
        {
            img.color = new Color(img.color.r, img.color.b, img.color.g, img.color.a + speed * Time.deltaTime);
        }
    }
    private IEnumerator Faderev()
    {
        img.color = new Color(img.color.r, img.color.b, img.color.g, 0.0f);
        yield return new WaitForSeconds(num);
        FadeOutImage(0.6f);
    }
}
