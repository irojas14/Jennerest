using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_continue : MonoBehaviour
{
    public float _crawlSpeed = 10.0f;
    private Vector3 movementVector = Vector3.zero;
    //public Transform target;
    public Animator animator;

    [SerializeField] private Text _zText;
    [SerializeField] private Text _xText;
    [SerializeField] private Text _eText;

    private bool isZPressed = false;
    private bool playerWillComeBack = false;
    private PlayerController _playerController;
    private SwapContinueController _swap;  
    private UIController _ui;
    private PauseMenuController _pause;


    
    // Start is called before the first frame update
    void Start()
    {
        //movementVector = (target.position - transform.position).normalized * _crawlSpeed;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _swap = GameObject.Find("SwapContinueManager").GetComponent<SwapContinueController>();
        _ui = GameObject.Find("UIManager").GetComponent<UIController>();
        _pause = GameObject.Find("PauseMenuManager").GetComponent<PauseMenuController>();

        _zText.enabled = true;
        _xText.enabled = false;
        _eText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(_pause.isPaused == false)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {   
                if(isZPressed == false)
                {
                    Crawl();
                    animator.SetBool("Mashing", true);
                    _zText.enabled = false;
                    _xText.enabled = true;
                    isZPressed = true;

                }
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                if(isZPressed == true)
                {
                    Crawl();
                    animator.SetBool("Mashing", true);
                    _zText.enabled = true;
                    _xText.enabled = false;
                    isZPressed = false;

                }
            }
            
            if(Input.GetKeyDown(KeyCode.E) && playerWillComeBack)
            {
                //_swap.playerIsComeBack = true;
                _eText.enabled = false;
                _playerController.playerContinueInstance = false;
                _playerController.PlayerComeBack();
            }

        }


    }


     void Crawl()
     {
        transform.position += new Vector3(0.05f,0.0f,0.0f)+ movementVector * Time.deltaTime;
     }


     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerContinue"))
        {
            _eText.enabled = true;
            _zText.enabled = false;
            _xText.enabled = false;
            playerWillComeBack = true;

        }
    }

}
