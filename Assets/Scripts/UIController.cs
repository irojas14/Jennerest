using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private Image [] _LivesImg;
    
    [SerializeField]
    private Sprite[] _liveSprites;

    private PlayerController _player;
    
    void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update() 
    {
        UpdateLives();    
    }
    // Start is called before the first frame update

    public void UpdateLives()
    {
        if(_player.health == 6)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = true;
            _LivesImg[2].enabled = true;
        }

        else if(_player.health == 4)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = true;
            _LivesImg[2].enabled = false;
        }

        else if(_player.health == 2)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = false;
            _LivesImg[2].enabled = false;
        }

        else
        {
            _LivesImg[0].enabled = false;
            _LivesImg[1].enabled = false;
            _LivesImg[2].enabled = false;          
        }
    }
}
