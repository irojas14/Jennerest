using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    [SerializeField] private Image [] _LivesImg;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private Text _enemysLeft;
    [SerializeField] private Text _finishMisionText;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private GameObject _finishLevel;
    
    private PlayerController _player;

    public int _enemysCount;
    
    void Start() 
    {
        _enemysCount = _enemys.Length;
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _enemysLeft.text = "Remaining Enemys: " + _enemysCount.ToString();
        _finishLevel.SetActive(false);
        _finishMisionText.enabled = false;
    }


    void Update() 
    {
        UpdateLives();
        if(_enemysCount==0)
        {  
            finishMissionText();
             _finishLevel.SetActive(true);
        }    
    }
    // Start is called before the first frame update

    public void UpdateLives()
    {
        if(_player.health == 3)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = true;
            _LivesImg[2].enabled = true;
        }

        else if(_player.health == 2)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = true;
            _LivesImg[2].enabled = false;
        }

        else if(_player.health == 1)
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

    public void updateEnemyCount()
    {
        _enemysCount--;
        _enemysLeft.text = "Remaining Enemys: " + _enemysCount.ToString();
    }

    public void finishMissionText()
    {
        _enemysLeft.enabled = false;
        _finishMisionText.enabled = true;   
    }
}
