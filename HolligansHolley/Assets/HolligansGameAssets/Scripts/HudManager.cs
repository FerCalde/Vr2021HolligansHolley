using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    Text timeText;
    Text scoreText;
    [SerializeField]GameObject[] imgVidas;

    // Start is called before the first frame update
    void Start()
    {
        //Me suscribo a los eventos del GameManager para recibirlos cuando se lanzan
        GameManager.Instance.OnUpdateScore += UpdateScore;
        GameManager.Instance.OnUpdateTimeText += UpdateTimeText;
        GameManager.Instance.OnUpdateLife += UpdateLifes;

        //Busco las referencias necesarias
        timeText = GameObject.Find("Text_Time").GetComponent<Text>();
        scoreText = GameObject.Find("Text_Score").GetComponent<Text>();

        //Actualizo los métodos desde Start para que se inicien bien en juego BUGCONTROL
        UpdateTimeText();
        UpdateScore();
        UpdateLifes();
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

}
