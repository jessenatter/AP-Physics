using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spring : MonoBehaviour
{
    public Slider slider;
    public float SpringPower;

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
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.NotYet:

                transform.localScale = new Vector2(.75f - slider.value, .3f);

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
        SpringPower = (.75f - transform.localScale.x ) * 25f;
        state = State.Hit;
    }
}
