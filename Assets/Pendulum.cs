using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    public float MoveByPendulum = 0;
    private float Angle = 0;
    private bool holding = true;
    private bool movingRight = false;
    private float FinalAngle;
    private float Direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveByPendulum = FinalAngle * Direction;

        if (Angle > 0)
        {
            movingRight = false;
            Direction = -1;
        }
        else
        {
            movingRight = true;
            Direction = 1;
        }

        transform.rotation = Quaternion.Euler(Vector3.forward * Angle);

        if(!holding)
        {
            if (movingRight == true)
            {
                Angle -= Time.deltaTime * 180;
            }
            
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
        FinalAngle = Mathf.Abs(Angle);
        holding = false;
    }
}
