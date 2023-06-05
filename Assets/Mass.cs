using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mass : MonoBehaviour
{
    public Rigidbody2D rb;
    public float KEpresent;
    public float PEpresent;
    public float Senergy;
    public float Penergy;

    public Text KEt;
    public Text PEt;

    private float MoveByPendulum = 0;
    private Pendulum P;
    private Spring S;

    public GameObject Pendulum;
    public GameObject Spring;
    public GameObject Glove;

    public GameObject Logic;

    public GameObject ground;

    private Logic L;

    private bool Frozen = true;

    private bool hasHit;

    private float startX;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        P = Pendulum.GetComponent<Pendulum>();
        S = Spring.GetComponent<Spring>();
        L = Logic.GetComponent<Logic>();
        Frozen = true;
        startX = transform.position.x;
        startY = transform.position.y;
        Senergy = 0f;
        Penergy = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        PEpresent = Mathf.RoundToInt( Mathf.Abs( (ground.transform.position.y - transform.position.y) * 10f ));

        KEpresent = Mathf.RoundToInt(rb.velocity.magnitude * rb.velocity.magnitude * .5f);


        KEt.text = KEpresent.ToString();
        PEt.text = PEpresent.ToString();

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
        Senergy = S.SpringPower;
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
        if (collision.gameObject.tag == "wall")
        {
//meem
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
                Penergy = MoveByPendulum;
            }
        }
        if (collision.gameObject.tag == "Spring")
        {
            if (hasHit == false)
            {
                HitBySpring();
            }
        }
        if (collision.gameObject.tag == "Flag")
        {
            L.Victory();
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
        //reset position
        Frozen = true;
        rb.mass = 0f;
        rb.gravityScale = 0f;
        transform.position = new Vector2(startX, startY);
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        hasHit = false;
    }
}
