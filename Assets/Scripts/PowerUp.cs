using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Powerup_1 = saltar mas alto
    // Powerup_2 = buffear el disparo
    // Powerup_3 = Moverse mas rapido
        
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.tag=="Player")
        {
            // Acceder al script del player,  aunque no me funca ayuda jesus
            /*
            GameObject player = collision.gameObject;
            Player playerScript = player.GetComponent<PlayerController>();
            playerScript.Jump_Height += 10f;
            */
            Pickup();
        }


    }

    void Pickup()
    {   
        Destroy(this.gameObject);
    }



}
