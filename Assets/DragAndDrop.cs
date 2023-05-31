using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isabove = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "mouse")
        {
            isabove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isabove = false;
    }
}