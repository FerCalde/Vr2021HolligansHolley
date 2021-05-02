using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject panelMainMenu, panelEndGame;
    [SerializeField] Text highScoreText;
    

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenHighScore()
    {
        DataScore.Instance.LoadHighScore();
        highScoreText.text = DataScore.Instance.highScore.ToString() + " points"; 
        panelEndGame.SetActive(true);
        panelMainMenu.SetActive(false);
    }
    public void OpenMenu()
    {
        panelMainMenu.SetActive(true);
        panelEndGame.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
