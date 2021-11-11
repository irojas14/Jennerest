using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{   
    //Prefab de la bala
    public GameObject _bulletPrefab;
   
    //Ubicación donde spawnea la bala (en el player) al ser disparada 
    public Transform _bulletSpawnReference;

    //Tiempo de espera entre cada disparo.
    [SerializeField]
    private float _nextFire;

    //Cantidad de disparo por segundo.
    [SerializeField]
    private float _fireRate = 0.5f;
    public Vector3 _shoot;

    //Se importa el script del player
    [SerializeField]
    private PlayerController playerInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _nextFire = _fireRate;
        playerInput = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        _shoot.x = _bulletSpawnReference.position.x;
        _shoot.y = _bulletSpawnReference.position.y;
        _shoot.z = _bulletSpawnReference.position.z;

        if (_nextFire > 0)
        {
          _nextFire -= Time.deltaTime ;  
            return;
        }
        
        //Al apretar Z, la bala se dispara según la dirección en la que el jugador esté mirando (en el eje x)
        if(Input.GetKey(KeyCode.Z))
        {
            _nextFire =_fireRate;
            Instantiate(_bulletPrefab, _shoot, _bulletSpawnReference.rotation);
        }

        
    }
}
