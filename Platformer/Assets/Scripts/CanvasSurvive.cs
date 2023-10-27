using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSurvive : MonoBehaviour
{
    public Canvas canvas;

    private static CanvasSurvive canvasInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (canvasInstance == null)
        {
            DontDestroyOnLoad(canvas);
            canvasInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
