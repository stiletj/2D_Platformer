using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    public Image backgroundImage;

    public Sprite[] srcImages;

    int current = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(current);
        backgroundImage.sprite = srcImages[current];
    }

    public int ChangeBackground(int newScene)
    {
        Debug.Log("Change: " +  newScene);

        if (newScene >= 0 && newScene < srcImages.Length)
        {
            current = newScene;
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
