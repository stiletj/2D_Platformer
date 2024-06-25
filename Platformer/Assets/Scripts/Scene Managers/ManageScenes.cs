using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GameManager;
    public Vector3 position = new Vector3(0, 0, 0);
    public string startingScene = "Outside 1";

    public static string lastScene = null;
    public static string currentScene = "Outside 1";
    public static int currentSceneInt = 0;
    public static bool changeScene = false;
    public static string sp;

    Vector2 currentVel = new Vector2(0, 0);
    public static GameObject player = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (startingScene == SceneManager.GetActiveScene().name && lastScene == null)
        {
            currentScene = startingScene;

            player = Instantiate(PlayerPrefab, position, Quaternion.identity);
            //gameManager = Instantiate(GameManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
            GameManager.GetComponent<ManageGame>().ChangeBackground(currentSceneInt);
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
