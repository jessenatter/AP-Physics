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
    private Spring S;
    private Glove G;

    public GameObject Pendulum;
    public GameObject Spring;
    public GameObject Glove;

    public GameObject Logic;

    private Logic L;

    private bool Frozen = true;

    private bool hasHit;

    private Transform start;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        P = Pendulum.GetComponent<Pendulum>();
        S = Spring.GetComponent<Spring>();
        G = Glove.GetComponent<Glove>();
        L = Logic.GetComponent<Logic>();
        Frozen = true;
        start.position = transform.position;
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
        hasHit = true;
        S.hit();
        rb.velocity = new Vector2(S.SpringPower, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ramp")
        {
            
        }

        if (collision.gameObject.tag == "Landing")
        {
            P.Release();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pendulum")
        {
            if (P.holding == false)
            {
                MoveByPendulum = P.MoveByPendulum;
                rb.velocity = new Vector2(MoveByPendulum, 0);
                P.hit();
            }
        }
        if (collision.gameObject.tag == "Spring")
        {
            if (hasHit == false)
            {
                HitBySpring();
            }
        }
        if (collision.gameObject.tag == "flag")
        {
           
        }


    }

    public void Unfreeze()
    {
        Frozen = false;
        rb.mass = 1f;
        rb.gravityScale = 1f;
    }

    public void Reset()
    {
        transform.position = start.position;
        Frozen = true;
        rb.mass = 0f;
        rb.gravityScale = 0f;

    }
}
