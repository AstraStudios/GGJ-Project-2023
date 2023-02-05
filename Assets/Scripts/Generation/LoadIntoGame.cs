using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntoGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Debug.Log("Trying to load scene ");
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Quiting Game!");
    }
}
