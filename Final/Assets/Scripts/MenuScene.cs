using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void MainMenu() {
        if(AudioManager.instance.isPlaying("Lose")) {
            AudioManager.instance.Stop("Lose");
        }

        if(AudioManager.instance.isPlaying("Win")) {
            AudioManager.instance.Stop("Win");
        }
        SceneManager.LoadScene("MainMenuScene");
    }

    public void StartGame() {
        if(AudioManager.instance.isPlaying("Lose")) {
            AudioManager.instance.Stop("Lose");
        }

        if(AudioManager.instance.isPlaying("Win")) {
            AudioManager.instance.Stop("Win");
        }
        SceneManager.LoadScene("Level1Scene 1");
    }

    public void Quit() {
        Application.Quit();
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.None;

        if(SceneManager.GetActiveScene().name == "FailedScene") {
            AudioManager.instance.Play("Lose");
        }

        if(SceneManager.GetActiveScene().name == "StageClearScene") {
            AudioManager.instance.Play("Win");
        }

        if(SceneManager.GetActiveScene().name == "MainMenuScene") {
            if(AudioManager.instance.isPlaying("Gravity")) {
                AudioManager.instance.Stop("Gravity");
            }

            if(AudioManager.instance.isPlaying("Lose")) {
                AudioManager.instance.Stop("Lose");
            }

            if(AudioManager.instance.isPlaying("Win")) {
                AudioManager.instance.Stop("Win");
            }
        }
    }
}
