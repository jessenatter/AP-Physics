using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Slider S1;
    public Slider S2;
    public Slider S3;
    public GameObject Mass;
    public GameObject deathscreen;

    private Mass mass;

    // Start is called before the first frame update
    void Start()
    {
        mass = Mass.GetComponent<Mass>();
        deathscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        deathscreen.SetActive(false);
        mass.Reset();
        S1.value = 0f;
        S2.value = 0f;
        S3.value = 0f;
    }
    public void Victory()
    {
        deathscreen.SetActive(true);
    }
    public void Retry()
    {

    }

}
