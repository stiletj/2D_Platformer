using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    public Image backgroundImage;
    public RectTransform backgroundPositions;

    public Sprite[] srcImages;
    public Vector3[] positions;

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

        if (current < srcImages.Length)
        {
            backgroundPositions.anchoredPosition = positions[current];
        }
        else
        {
            backgroundPositions.anchoredPosition = Vector3.zero;
        }
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
