using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mass : MonoBehaviour
{
    public Rigidbody2D rb;
    public float KEpresent;
    public float PEpresent;

    private float MoveByPendulum = 0;
    private Pendulum P;

    public GameObject Pendulum;
    private bool Frozen = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        P = Pendulum.GetComponent<Pendulum>();
        Frozen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Frozen == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.mass = 0f;
            rb.gravityScale = 0f;
        }

    }

    public void HitBySpring()
    {
        rb.velocity = new Vector2(5, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spring")
        {
            HitBySpring();
        }

        if (collision.gameObject.tag == "Pendulum")
        {
            if (P.holding == false)
            {
                MoveByPendulum = P.MoveByPendulum;
                rb.velocity = new Vector2(MoveByPendulum, 0);
                P.hit();
            }
        }

        if (collision.gameObject.tag == "Ramp")
        {
            
        }

        if (collision.gameObject.tag == "Landing")
        {
            P.Release();
        }
    }
    public void Unfreeze()
    {
        Frozen = false;
        rb.mass = 1f;
        rb.gravityScale = 1f;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void test()
    {
        rb.velocity = new Vector2(-6,0);
    }
}
