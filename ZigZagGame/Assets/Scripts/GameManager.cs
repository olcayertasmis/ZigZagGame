using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private PlayerController player;

    public void RestartGame()
    {
        player.isStart = false;

        var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);

        uIManager.RestartPanel(false);
        uIManager.PlayPanel(true);
    }

    public void StartGame()
    {
        player.isStart = true;
        uIManager.RestartPanel(false);
        uIManager.PlayPanel(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
