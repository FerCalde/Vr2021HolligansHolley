using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScore : PersistentSingleton<DataScore>
{
    public int highScore = 0;

    //Datos PlayerPrefs
    string keyHighScore = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(keyHighScore);
    }

    public void SaveHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt(keyHighScore, newHighScore);
        LoadHighScore();
    }

    public void CheckHighScore(int currentScored)
    {
        LoadHighScore();
        //Comprobar si el resultado es mayor que el highScoreGuardado
        if (currentScored > highScore)
        {
            SaveHighScore(currentScored);
            LoadHighScore();
        }
    }
}
