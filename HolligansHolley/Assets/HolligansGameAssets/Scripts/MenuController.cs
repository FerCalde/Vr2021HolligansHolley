using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject panelMainMenu, panelEndGame, panelBorrarGame;
    [SerializeField] Text highScoreText;


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenHighScore()
    {
        UpdateHighScoreText();
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


    public void OpenPanelBorrarScore()
    {
        panelBorrarGame.SetActive(true);
    }

    public void ClosePanelBorrarScore()
    {
        panelBorrarGame.SetActive(false);
    }

    public void BorrarScore()
    {
        DataScore.Instance.SaveHighScore(0);
        UpdateHighScoreText();
        ClosePanelBorrarScore();
    }

    void UpdateHighScoreText()
    {
        DataScore.Instance.LoadHighScore();
        highScoreText.text = DataScore.Instance.highScore.ToString() + " points";
    }
}
