using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapContinueController : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerContinue;
    [SerializeField] private GameObject _playerContinueTexts;

    private PlayerController _playerController;
    //public bool playerIsComeBack = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerContinue.SetActive(false);
        _playerContinueTexts.SetActive(false);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerController.playerContinueInstance == true)
        {
            playerinGround();
        }

        else
        {
            playerContinue();
        }
    }


    void playerinGround()
    {
        _player.SetActive(false);
        _playerContinue.SetActive(true);
        _playerContinueTexts.SetActive(true);
    }

    void playerContinue()
    {
        _player.SetActive(true);
        _playerContinue.SetActive(false);
        _playerContinueTexts.SetActive(false);
    }

}
