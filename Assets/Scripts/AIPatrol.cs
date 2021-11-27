using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{

    // Enemy Movement and Player Detection
    public float walkSpeed = 2f;
    public bool patrolCheck;
    public float patrolTime = 2f;
    public float aggroRange = 10f;
    float patrolTimer;
    Transform playerTransform;

    // Shooting variables

    public GameObject bulletPrefab;
    public float fireDelay = 0.5f;
    float shootCooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        patrolCheck = true;
        patrolTimer = patrolTime;
    }

    // Update is called once per frame
    void Update()
    {
        patrolTimer -= Time.deltaTime;
        if (patrolCheck)
        {
            PlayerSearch();
            Patrol();
        }
        else
        {
            shootCooldown -= Time.deltaTime;
            Aggro();
        }
    }
    void Patrol()
    {
        if (Mathf.Sign(walkSpeed) == Mathf.Sign(transform.localScale.x))
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        Vector3 pos = transform.position;
        pos.x += walkSpeed*Time.deltaTime;
        transform.position = pos;
        if (patrolTimer <= 0)
        {
            Flip();
            patrolTimer = patrolTime;
        }
    }
    void Flip()
    {
        patrolCheck = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        patrolCheck = true;
    }
    void PlayerSearch()
    {
        GameObject playerObject = GameObject.Find("Player");
        if(playerObject != null)
        {
            // Get distance to player
            playerTransform = playerObject.transform;
            Vector3 distance = playerTransform.position - transform.position;  
            // If inside aggro range stop patrolling
            if (distance.magnitude <= aggroRange)
            {
                patrolCheck = false;
                Debug.Log("aggro");
            }
           
        }
    }
    void Aggro()
    {
        // Get direction
        Vector3 direction = playerTransform.position - transform.position;
        // Check if player gets out of range
        if (direction.magnitude >= aggroRange)
        {
            patrolCheck = true;
            return;
        }
        Vector3 pos = transform.position;
        direction.Normalize();
        Shoot();
        // Flip sprite
        if (Mathf.Sign(direction.x) == Mathf.Sign(transform.localScale.x)){
            transform.localScale = new Vector2(transform.localScale.x *-1, transform.localScale.y);
        }
        // Run at player
        pos.x += Mathf.Abs(walkSpeed)*Time.deltaTime*direction.x;
        transform.position = pos;
    }
    void Shoot()
    {
        if (shootCooldown <= 0)
        {
            shootCooldown = fireDelay;
            Quaternion rot;
            if (Mathf.Sign(transform.localScale.x) == 1)
            {
                rot = Quaternion.Euler(0,0,90);
            }
            else
            {
                rot = Quaternion.Euler(0,0,-90);
            }
            Instantiate(bulletPrefab, transform.position, rot);
        }
    }

}
