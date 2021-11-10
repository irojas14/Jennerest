using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //Bullets
    //private Bullets bullet;
    
    private float rotation;
    
    //Fire rate player
    public float fireRate;
    private float playerCanFire;

    //Delegate to kill player
    public delegate void Kill_Player();
    public Kill_Player Death;

    //Bullet position
    public Transform bullet_location;

    //GameObjects
    public GameObject Bullet_Boss;
    public GameObject HealthPowerUp;
    public GameObject GunPowerUp;

    //Player Momenet Speed
    public float MovementSpeed = 20.0f;
    //public float JumpForce = 8f;

    //Player hp
    public float hp;

    //Player jump Height
    public float Jump_Height;

    private bool Is_Player_Jumping = false;
    
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        */

        //Con esta se evita que el jugador rote al chocar con elementos del mapa.
        var movement = Input.GetAxis("Horizontal");
        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        Control_Player();
        Jump();
        //Shooting();
        
    }

    private void Control_Player()
    {
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
        }
    }


    private void Jump()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Is_Player_Jumping == false)
            {
                Is_Player_Jumping = true;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * Jump_Height);
            }

        }
        */

        //Salto
        if (Input.GetButton("Jump") && Mathf.Abs(_rigidBody.velocity.y) < 0.001f)
        {
            _rigidBody.AddForce(new Vector2(0, Jump_Height), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        
        if(col.gameObject.tag == "Ground")
        {
            Is_Player_Jumping = false;
        }

    }

    /*
    private void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Bullets bullet = pool.shoot();
            bullet.transform.position = bullet_location.position;
            bullet.transform.rotation = bullet_location.rotation;
            playerCanFire = fireRate;
            bullet.Fire();   
        }
    }
    */
    /*
    public void Kill_Player()
    {

    }
    */

}
