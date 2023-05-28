using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    public float MoveByPendulum = 0;
    private float Angle = 0;
    public bool holding = true;
    private float FinalAngle;
    private float Direction;

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

                transform.rotation = Quaternion.Euler(Vector3.forward * Angle);

                if (!holding)
                {
                   Angle += Time.deltaTime * 210 * -Direction ;
                }

                break;

            case State.Hit:

                transform.rotation = Quaternion.Euler(Vector3.forward * 0);

                break;
        }
    }
    public void PlusAngle()
    {
        Angle += 5;
    }
    public void MinusAngle()
    {
        Angle -= 5; 
    }
    public void Release()
    {
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

        Debug.Log(MoveByPendulum);
    }
    public void hit()
    {
        state = State.Hit;
    }
}
