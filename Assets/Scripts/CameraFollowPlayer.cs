using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform Player;

    public Vector2 Margin, Smoothing;

    public BoxCollider2D Bounds;

    private Vector3 _min, _max;

    public bool IsFolllowing { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        IsFolllowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if (IsFolllowing)
        {
            if (Mathf.Abs(x-Player.position.x) > Margin.x)
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
            if (Mathf.Abs(y-Player.position.y) > Margin.y)
                x = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
        }

        var CameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

        x = Mathf.Clamp(x, _min.x + CameraHalfWidth, _max.x - CameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);

        transform.position = new Vector3(x,y,transform.position.z);
    }
}
