using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneSwitcher : ScriptableObject {

    public GlobalString mainMenuName;
    public GlobalString level1Name;
    public GlobalString gameOverName;

    public void MainMenu(){
        SceneManager.LoadScene(mainMenuName.Value);
    }

    public void StartGame(){
        SceneManager.LoadScene(level1Name.Value);
    }

    public void GameOver(){
        SceneManager.LoadScene(gameOverName.Value);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
