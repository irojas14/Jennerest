using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private Image [] _LivesImg;
    
    [SerializeField]
    private Sprite[] _liveSprites;

    [SerializeField]
    private Text _enemysLeft;

    [SerializeField]
    private GameObject[] _enemys;

    private PlayerController _player;

    public int _enemysCount;
    
    void Start() 
    {
        _enemysCount = _enemys.Length;
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _enemysLeft.text = "Remaining Enemys: " + _enemysCount.ToString();
    }


    void Update() 
    {
        UpdateLives();
        if(_enemysCount==0)
        {
            SceneManager.LoadScene("WinScene");
        }    
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

    public void updateEnemyCount()
    {
        _enemysCount--;
        _enemysLeft.text = "Remaining Enemys: " + _enemysCount.ToString();
    }
}
