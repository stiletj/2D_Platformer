using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Vector3 position = new Vector3(0, 0, 0);
    public string startingScene = "Outside 1";

    public static string lastScene = null;
    public static string currentScene = "Outside 1";
    public static bool changeScene = false;
    public static string sp;

    Vector2 currentVel = new Vector2(0, 0);
    GameObject player = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startingScene == SceneManager.GetActiveScene().name && lastScene == null)
        {
            player = Instantiate(PlayerPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == currentScene && changeScene)
        {
            FirstSceneFrame();
        }

        if (player != null)
        {
            currentVel = player.GetComponent<PlayerMove>().controller.velocity;
        }

        if (changeScene)
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    void FirstSceneFrame()
    {
        Debug.Log("FirstSceneFrame");

        changeScene = false;

        player.transform.position = GameObject.Find(sp).transform.position;
        PlayerMove.startVelocity = currentVel;
    }
}
