using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    public float _speed = 15.0f;

    [SerializeField]
    private float _bulletLifeTime = 3f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, _speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        _bulletLifeTime -= Time.deltaTime;

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
        if(other.gameObject.layer != 6)
        {
            if(other.gameObject.layer != 10)
            {
                Destroy(gameObject);
            }
        }
    }
}
