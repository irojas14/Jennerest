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
    public GameObject otherObject;
    public GameObject smoothObject;
    Animator otherAnimator;
    CameraSmoothFollow smoothFloat;
    public float smooth;
    public bool _isFade=false;


    void Awake ()
    {
         otherAnimator = otherObject.GetComponent<Animator> ();
         smoothFloat = smoothObject.GetComponent<CameraSmoothFollow>();
         
    }
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
            if (_isFade == false)
            {
                StartCoroutine(Fade());
                _isFade = true;
            }
        }

        else
        {
            if (_isFade == true)
            {
                StartCoroutine(Fadent());
                _isFade = false;
            }
        }
    }


    private IEnumerator Fade()
    {   
        smoothFloat.smoothSpeed = 0.0f;
        otherAnimator.SetBool("Trigger",true) ;
        _playerContinue.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        _player.SetActive(false);
        smoothFloat.smoothSpeed = 0.125f;
        _playerContinueTexts.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        otherAnimator.SetBool("Trigger",false) ;
        
    }

    private IEnumerator Fadent()
    {   
        smoothFloat.smoothSpeed = 0.0f;
        otherAnimator.SetBool("Trigger",true) ;

        yield return new WaitForSeconds(1.0f);

        _player.SetActive(true);
        smoothFloat.smoothSpeed = 0.125f;

        yield return new WaitForSeconds(0.5f);

        _playerContinue.SetActive(false);
        _playerContinueTexts.SetActive(false);
        otherAnimator.SetBool("Trigger",false) ;
        
    }
}
