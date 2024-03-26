using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Start loads the main game scene
    /// </summary>
    public void StartGame() => SceneManager.LoadSceneAsync("MainGame");

    /// <summary>
    /// Quit exits the game
    /// </summary>
    public void Quit() => Application.Quit();
}
