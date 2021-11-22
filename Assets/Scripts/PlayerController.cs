using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public float rotation;
    
    private float playerCanFire;

    //Delegate to kill player
    public delegate void Kill_Player();
    public Kill_Player Death;

    //GameObjects
    public GameObject Bullet_Boss;
    public GameObject HealthPowerUp;
    public GameObject GunPowerUp;

    //Player Momenet Speed
    [SerializeField]
    private float MovementSpeed;

    //Player jump Height
    [SerializeField]
    private float Jump_Height;

    //Player health
    public int health = 5;
    public int scoreWorth = 0;

    //Hit Invulnerability
    public float invulnTime = 2f;
    float invulnTimer = 0;

    //Variable que usaremos en caso de aplicar animaciones
    //private bool Is_Player_Jumping = false;
    
    private Rigidbody2D _rigidBody;

    //PowerUps flags and variables
    [SerializeField] private float _speedMultiplier = 1.3f;
    [SerializeField] private float _jumpHeightMultiplier = 1.3f;

        
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
        }
        Control_Player();
        Jump();
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
          
        /* 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Sprite Rotation
            transform.eulerAngles = new Vector2(0,0);
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            rotation = 1f;
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            rotation = -1f;
        }

        else
        {
            rotation = 0;
        } */


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
            Destroy(gameObject);
            //Se cambia de escena y aparece que el jugador perdió
            SceneManager.LoadScene(2);
        }
        //ScoreManager.AddScore(scoreWorth);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 7)
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


