using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    public int scoreWorth = 0;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer != 0)
        {
            if (other.gameObject.layer != 8)
            {
                health--;
            }

        }
    }
    private void Update() {
        if (health <= 0){
            Die();
        }
    }
    private void Die(){
        Destroy(gameObject);
        //ScoreManager.AddScore(scoreWorth);
    }
}
