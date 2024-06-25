using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string scene;
    public int sceneBuildIndex;
    public string spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Change");

        ManageScenes.lastScene = ManageScenes.currentScene;
        ManageScenes.currentScene = scene;
        ManageScenes.currentSceneInt = sceneBuildIndex;
        ManageScenes.changeScene = true;
        ManageScenes.sp = spawnPoint;
    }
}
