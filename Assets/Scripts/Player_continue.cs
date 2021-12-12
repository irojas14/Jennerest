using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_continue : MonoBehaviour
{
    public float _crawlSpeed = 10.0f;
    private Vector3 movementVector = Vector3.zero;
    public Transform target;

    public Animator animator;   


    // Start is called before the first frame update
    void Start()
    {
        movementVector = (target.position - transform.position).normalized * _crawlSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Crawl();
            animator.SetBool("Mashing", true);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Crawl();
            animator.SetBool("Mashing", true);
        }
    }


     void Crawl()
     {
        
        transform.position += new Vector3(0.05f,0.0f,0.0f)+ movementVector * Time.deltaTime;
     }


     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("SUBETE AL JENNEREST Shinji!");
        }
    }
}
