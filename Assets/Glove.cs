using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glove : MonoBehaviour
{
    public Slider slider;
    private float move;
    private float grabbed;
    public GameObject spring;
    //mopve max = 2
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grabbed = spring.transform.position.x + 5.28f;
        move = slider.value / 0.35f * -2;
        transform.position = new Vector2(grabbed + move, transform.position.y);
    }

    public void hit()
    {
        transform.position = new Vector2(grabbed, transform.position.y);
        Debug.Log("hit");
    }
}
