using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    public int enemyHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 6 && other.gameObject.tag == "Player")
        {

            PlayerController player = other.transform.GetComponent<PlayerController>();

            EnemyDamage();
            if (player != null)
            {
                player.Damage();
            }

        }

        else if (other.gameObject.layer == 6 && other.gameObject.tag == "Bullet")
        {
            EnemyDamage();
        }

    }

    private void EnemyDamage()
    {
        enemyHealth-=1;

        if(enemyHealth < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
