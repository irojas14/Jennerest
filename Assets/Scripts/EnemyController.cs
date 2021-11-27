using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public int enemyHealth = 1;
    private UIController _ui;
    private bool enemyDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("UIManager").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyDeath=false;  
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
            if(enemyDeath==false)
            {
                Destroy(this.gameObject);
                enemyDeath=true;
                if(enemyDeath==true)
                {
                    _ui.updateEnemyCount();
                }
            }
            
        }  
    }
}
