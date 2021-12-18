using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{

    [SerializeField] private Image [] _LivesImg;
    [SerializeField] private Text _mission;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private GameObject _finishLevel;
    [SerializeField] private Text _livesText;
    
    private PlayerController _player;
    public Text _finishMisionText;

    public int _enemysCount;
    public int _itemsCount;
    
    void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        if(SceneManager.GetActiveScene().name == "AlphaLevel")
        {
            _enemysCount = _enemys.Length;
            _mission.text = "Remaining Enemys: " + _enemysCount.ToString();
        }

        else if(SceneManager.GetActiveScene().name == "AlphaLevel2")
        {
            _itemsCount = _items.Length;
            _mission.text = "Remaining Items: " + _itemsCount.ToString();
        }
        _finishLevel.SetActive(false);
        _finishMisionText.enabled = false;
    }


    void Update() 
    {
        UpdateLives();

        if(SceneManager.GetActiveScene().name == "AlphaLevel")
        {
            if(_enemysCount==0)
            {  
                finishMissionText();
                _finishLevel.SetActive(true);
            }    
        }

        else if(SceneManager.GetActiveScene().name == "AlphaLevel2")
        {
            if(_itemsCount==0)
            {
                finishMissionText();
                _finishLevel.SetActive(true);
            }
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

            _livesText.enabled = true;
            _mission.enabled = true;
        }

        else if(_player.health == 2)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = true;
            _LivesImg[2].enabled = false;

            _mission.enabled = true;
            _livesText.enabled = true;


        }

        else if(_player.health == 1)
        {
            _LivesImg[0].enabled = true;
            _LivesImg[1].enabled = false;
            _LivesImg[2].enabled = false;
            
            _mission.enabled = true;
            _livesText.enabled = true;
        }

        else
        {
            _LivesImg[0].enabled = false;
            _LivesImg[1].enabled = false;
            _LivesImg[2].enabled = false;
            
            _mission.enabled = false;
            _livesText.enabled = false;
                
        }

    }

    public void updateEnemyCount()
    {
        _enemysCount--;
        _mission.text = "Remaining Enemys: " + _enemysCount.ToString();
    }

    public void UpdateItemsCount()
    {
        _itemsCount--;
        _mission.text = "Items Count: " + _itemsCount.ToString();
    }

    public void finishMissionText()
    {
        _mission.enabled = false;
        _finishMisionText.enabled = true;   
    }

}
