using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glove : MonoBehaviour
{
    public Slider slider;
    private float move;
    private float grabbed = 0f;
    public GameObject spring;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = spring.transform.position.x + 5.19f;
        grabbed = (slider.value / 0.35f) * -2f;
        transform.position = new Vector2(move + grabbed, spring.transform.position.y);
    }
}


