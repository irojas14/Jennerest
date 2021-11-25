using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Velocidad de cada bala.
    public float _speed = 15.0f;

    //Variable que le asigna la cantidad de segundos que tendrá de vida cada bala
    [SerializeField]
    private float _bulletLifeTime = 3f;

    // Update is called once per frame
    void Update()
    {
        //La bala se desplaza por el eje x
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        
        //Cada segundo que pasa se le resta 1 al tiempo de vida de cada bala.
        _bulletLifeTime -= Time.deltaTime;
        
        //Cuando pasan los 3 segundos, las balas se destruyen de la escena.
        if(_bulletLifeTime <= 0)
        {
            //check if the object has a parent
            //destroy the parent to
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer != 8)
        {
            if(other.gameObject.layer != 10)
            {
                Destroy(gameObject);
            }
        }
    }

}
