using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    public Collider2D ccollider;
    public SpriteRenderer SR;
    public bool hovering = false;

    void Start()
    {
        //ccollider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (ccollider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                dragging = true;
            }


        }
        if (dragging)
        {
            this.transform.position = mousePos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
        }


        //added stuff 
        if (ccollider == Physics2D.OverlapPoint(mousePos))
        {
            hovering = true;
        }
        else
        {
            hovering = false;
        }
    }
}