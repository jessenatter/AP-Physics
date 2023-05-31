using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colordimmer : MonoBehaviour
{
    private SpriteRenderer SR;
    public GameObject dragNdrop;
    private DragAndDrop DAD;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        DAD = dragNdrop.GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
       if (DAD.isabove == false)
        {
            SR.color = new Color(1f, 1f, 1f, 1f);
        }

       if (DAD.isabove == true)
        {
            SR.color = new Color(.5f, .5f, .5f, 1f);
        }

    }
}
