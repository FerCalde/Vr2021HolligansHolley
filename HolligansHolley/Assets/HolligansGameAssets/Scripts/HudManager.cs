using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    Text timeText;
    Text scoreText;
    [SerializeField]GameObject[] imgVidas;

    GameObject panelHud;
    [SerializeField]GameObject panelEndGame;
    [SerializeField]Text highScoreText;
    [SerializeField]Text endScoreText;
    [SerializeField]GameObject newRecordText; 

    // Start is called before the first frame update
    void Start()
    {
        //Me suscribo a los eventos del GameManager para recibirlos cuando se lanzan
        GameManager.Instance.OnUpdateScore += UpdateScore;
        GameManager.Instance.OnUpdateTimeText += UpdateTimeText;
        GameManager.Instance.OnUpdateLife += UpdateLifes;
        GameManager.Instance.OnUpdateEndGame += UpdateEndGame;

        //Busco las referencias necesarias
        panelHud = GameObject.Find("Panel_HUD");
        //panelEndGame = GameObject.Find("Panel_EndGame");
        timeText = GameObject.Find("Text_Time").GetComponent<Text>();
        scoreText = GameObject.Find("Text_Score").GetComponent<Text>();
        //endScoreText = GameObject.Find("Text_EndScore").GetComponent<Text>();
        //highScoreText = GameObject.Find("Text_HighScore").GetComponent<Text>();
        //newRecordText = GameObject.Find("Text_NewRecord");

        //Desactivo elementos de interfaz del EndGame
        newRecordText.SetActive(false);
        panelEndGame.SetActive(false);
    }


    void UpdateTimeText()
    {
        timeText.text = Mathf.RoundToInt(GameManager.Instance.CurrentPlayTime).ToString() + " .s";
    }

    void UpdateScore()
    {
        scoreText.text = GameManager.Instance.CurrentScore.ToString() + " points";
    }

    void UpdateLifes()
    {
        //Feedback desactivar corazones HUD
        for (int i = 1; i <=3; i++)
        {
            if (GameManager.Instance.CantVidas >= i)
            {
                imgVidas[i - 1].SetActive(true);
            }
            else
            {
                imgVidas[i - 1].SetActive(false);
            }
        }
    }
    
    void UpdateEndGame()
    {
        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = DataScore.Instance.highScore;
        endScoreText.text = currentScore.ToString() + " points";
        highScoreText.text = highScore.ToString() + " points";
        if(currentScore>= highScore)
        {
            newRecordText.SetActive(true);
        }
        panelEndGame.SetActive(true); 
        panelHud.SetActive(false);
    }

}
