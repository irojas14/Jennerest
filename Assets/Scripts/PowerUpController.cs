using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Powerup_1 = saltar mas alto
    // Powerup_2 = buffear el disparo
    // Powerup_3 = Moverse mas rapido
    [SerializeField]
    private int _powerupId;
    //public float moreHeight = 4f;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag=="Player")
        {
            PlayerController player = other.transform.GetComponent<PlayerController>();
            PlayerShootController bullet = other.GetComponent<PlayerShootController>();
            if(player != null)
            {
                switch(_powerupId)
                {
                    case 0:
                        player.HigherJump();
                        break;
                    case 1:
                        bullet.BuffBullets();
                        break;
                    case 2:
                        player.FastMovement();
                        break;
                    default:
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }  
}
   
