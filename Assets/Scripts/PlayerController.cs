using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Animator animator;   
    public float rotation;
    
    private float playerCanFire;

    /*
    //Delegate to kill player
    public delegate void Kill_Player();
    public Kill_Player Death;
    */

    //GameObjects
    public GameObject Bullet_Boss;
    public GameObject HealthPowerUp;
    public GameObject GunPowerUp;

    //Player Momenet Speed
    [SerializeField] private float MovementSpeed;

    //Player jump Height
    [SerializeField] private float Jump_Height;

    //PowerUps flags and variables
    [SerializeField] private float _speedMultiplier = 1.7f;
    [SerializeField] private float _jumpHeightMultiplier = 1.7f;

    //Player health
    public int health = 3;
    public int scoreWorth = 0;

    //Hit Invulnerability
    public float invulnTime = 1f;
    float invulnTimer = 0;
    
    private Rigidbody2D _rigidBody;
    private bool damageFlag = false;
    private bool playerHasDeadBefore = false;


        
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
        {
            gameObject.layer = 6;
            damageFlag = false;
        }
        Control_Player();
        Jump();
        
        if (Mathf.Abs(Input.GetAxis("Horizontal"))>0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

    public void Control_Player()  
    {
        Vector3 pos = transform.position;

        pos.x += Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") > 0) 
        {
            transform.eulerAngles = new Vector2(0,0);
            rotation = 1f;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rotation = -1f;
        }


        else 
        {
            rotation = -1f;
        }
        transform.position = pos;

    }


    public void Jump()
    {
        //Salto
        if (Input.GetButton("Jump") && Mathf.Abs(_rigidBody.velocity.y) < 0.001f)
        {
            _rigidBody.AddForce(new Vector2(0, Jump_Height), ForceMode2D.Impulse);
            
        }
    }

    public void Damage()
    {

        health -= 1;
        invulnTimer = invulnTime;
        gameObject.layer = 9;
        Debug.Log("La vida del player es: " + health);
        if (health <= 0)
        {

            if(playerHasDeadBefore == false)
            {
                playerHasDeadBefore = true;
                SceneManager.LoadScene("NotDeadYet");
            }

            else
            {
                Destroy(gameObject);
                //Se cambia de escena y aparece que el jugador perdió
                SceneManager.LoadScene("PlayerDead");
            }

        }
        //ScoreManager.AddScore(scoreWorth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(damageFlag) return;
        damageFlag = true;
        if (collision.gameObject.layer == 7)
        {
            Damage();
        }
    }

    public void HigherJump()
    {
        Jump_Height *= _jumpHeightMultiplier;
        StartCoroutine(HigherJumpDownCoroutine());
    }

    IEnumerator HigherJumpDownCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        Jump_Height /= _jumpHeightMultiplier;
    }

    public void FastMovement()
    {
        MovementSpeed *= _speedMultiplier;
        StartCoroutine(FastMovementDownCoroutine());
    }

    IEnumerator FastMovementDownCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        MovementSpeed /= _speedMultiplier;
    }

    
}


