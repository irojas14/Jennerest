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

    //Player hp
    public float hp;

    //Player jump Height
    public float Jump_Height;

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

    /*
    void Shooting()
    {
        _nextFire = Time.time + _fireRate;
        Instantiate(_bulletPrefab, transform.position + new Vector3(1.05f, 0, 0), Quaternion.identity);
    }
    */

    /*
    public void Kill_Player()
    {

    }
    */

}
