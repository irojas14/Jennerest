using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{

    public float walkSpeed = 2f;
    public bool patrolCheck;
    public float patrolTime = 2f;
    float patrolTimer;
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
            Patrol();
        }
    }
    void Patrol()
    {
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
}
