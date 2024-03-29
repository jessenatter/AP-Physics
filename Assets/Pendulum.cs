using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendulum : MonoBehaviour
{

    public float MoveByPendulum = 0;
    public float Angle = 0;
    public bool holding = true;
    private float FinalAngle;
    private float Direction;
    public Slider slider;
    public float PundulumNRG;

    public float ANGLE;

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
    }

    // Update is called once per frame
    void Update()
    {

        text.text = PundulumNRG.ToString();

        ANGLE = transform.rotation.z;

        switch (state)
        {
            default:
            case State.NotYet:

                transform.rotation = Quaternion.Euler(Vector3.forward * Angle);
                PundulumNRG = Mathf.RoundToInt( 2f * 10f * ( 2f - (2f * Mathf.Cos(ANGLE))));

                if(holding)
                {
                    Angle = slider.value * -1;
                }

                if (!holding)
                {
                   Angle += Time.deltaTime * 210 * -Direction;
                }

                break;

            case State.Hit:


                transform.rotation = Quaternion.Euler(Vector3.forward * 0);

                break;
        }
    }

    public void Release()
    {

        if (Angle == 0)
        {
            state = State.Hit;
            return;
        }

        FinalAngle = Angle;
        
        holding = false;

        if (FinalAngle < 0)
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }

        MoveByPendulum = (-FinalAngle) / 10f;
    }
    public void hit()
    {
        state = State.Hit;
    }
    public void reset()
    {
        state = State.NotYet;
        holding = true;
    }
}
