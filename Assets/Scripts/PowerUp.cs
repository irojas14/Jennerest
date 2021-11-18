using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Powerup_1 = saltar mas alto
    // Powerup_2 = buffear el disparo
    // Powerup_3 = Moverse mas rapido
    public int _powerupId;
    public float moreHeight = 4f;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.tag=="Player")
        {
            if (_powerupId == 1)
            {
                Debug.Log("Recogido power up 1");
            }
            else if (_powerupId == 2)
            {
                Debug.Log("Recogido power up 2");
            }
            else if (_powerupId == 3)
            {
                Debug.Log("Recogido power up 3");
            }

            else
            {
                Debug.Log("No hay id");
            }
        
            Destroy(this.gameObject);
        }
    }  
}
   
