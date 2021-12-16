using UnityEngine;
public class CameraSmoothFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    
    private PlayerController _playerController;

    [SerializeField] private GameObject playerContinue;
    [SerializeField] private GameObject player;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(_playerController.playerContinueInstance)
        {
            target = playerContinue.transform;
        }

        else
        {
            target = player.transform;
        }
    }

    void FixedUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
