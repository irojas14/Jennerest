using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    private UIController _ui;
    // Start is called before the first frame update
    void Start()
    {
        _ui = GameObject.Find("UIManager").GetComponent<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6 && other.gameObject.tag == "Player")
        {
            itemCollected();
        }

    }

    void itemCollected()
    {
        Debug.Log("Tocando capsula");
        _ui.UpdateItemsCount();
        Destroy(this.gameObject);
    }
}
