using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    
    public float time = 0f;
    public int mins = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time >= 60f)
        {
            time = 0f;
            mins++;
        }

        timer.text = mins.ToString() + ":" + time.ToString("n2");
    }
}
