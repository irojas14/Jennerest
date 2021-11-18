using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float MovementSpeed = 20.0f;

    

    //Player jump Height
    public float Jump_Height;

    //Player health
    public int health = 5;
    public int scoreWorth = 0;

    //Variable que usaremos en caso de aplicar animaciones
    //private bool Is_Player_Jumping = false;
    
    private Rigidbody2D _rigidBody;

        
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Control_Player();
        Jump();
    }

    private void Control_Player()  
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
        // Wea pa tepear 
        else if(Input.GetKey(KeyCode.T))
        {
            pos=new Vector3(-15.5f,26f,0f); 
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


    private void Jump()
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
        Debug.Log("La vida del player es: " + health);
        if (health < 1)
        {
            Destroy(gameObject);
        }
        //ScoreManager.AddScore(scoreWorth);
    }
    public void AddJump(float moreHeight)
    {
        Jump_Height += moreHeight;

    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 7)
        {
            Damage();
        }
    }

}
