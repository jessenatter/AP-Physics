using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spring : MonoBehaviour
{
    public Slider slider;
    public float SpringPower;
    public Text text;


    private enum State
    {
        NotYet,
        Hit,
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.NotYet;
        SpringPower = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = SpringPower.ToString();

        switch (state)
        {
            default:
            case State.NotYet:

                transform.localScale = new Vector2(.75f - slider.value, .3f);
                SpringPower = Mathf.RoundToInt( .5f * (slider.value * slider.value) * 100f);

                break;

            case State.Hit:

                if (transform.localScale.x < .75f)
                {
                    transform.localScale = new Vector2(.75f, .3f);
                }
          
                break;
        }
    }

    public void hit()
    {
        state = State.Hit;
        slider.value = 0;
    }

    public void reset()
    {
        state = State.NotYet;
        SpringPower = 0f;
    }
}
