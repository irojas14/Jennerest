using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public int enemyHealth = 1;
    private UIController _ui;
    private bool enemyDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            _ui = GameObject.Find("UIManager").GetComponent<UIController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyDeath=false;  
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 && collision.gameObject.tag == "Player")
        {
            EnemyDamage();
        }

        else if (collision.gameObject.layer == 6 && collision.gameObject.tag == "Bullet")
        {
            EnemyDamage();
        }

    }

    public void EnemyDamage()
    {
        enemyHealth-=1;

        if(enemyHealth < 1)
        {
            if(enemyDeath==false)
            {
                Destroy(this.gameObject);
                enemyDeath=true;
                if(enemyDeath==true && SceneManager.GetActiveScene().name == "AlphaLevel")
                {
                    _ui.updateEnemyCount();
                }
            }
            
        }  
    }
}
