using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Powerup_1 = saltar mas alto
    // Powerup_2 = buffear el disparo
    // Powerup_3 = Moverse mas rapido
    
    public float moreHeight = 4f;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.tag=="Player")
        {
            /*Player jumpheight = other.gameObject.GetComponent<Player>();

            jumpheight.AddJump(moreHeight);*/            
            Destroy(this.gameObject);
        }
    }  

   



}
