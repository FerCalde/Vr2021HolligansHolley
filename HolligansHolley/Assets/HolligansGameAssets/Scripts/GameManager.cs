using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TemporalSingleton<GameManager>
{
    int currentScore = 0;

    int cantVidas = 3; //En caso de que queramos que los enemigos disparen y nos mate la tercera bala

    float maxPlayTime = 60f;
    float currentPlayTime;
    /*  #region Singleton
      public static GameManager Instance;

      void Awake()
      {
          Instance = this;
      }
      #endregion   */

    public delegate void OnUpdateHUD();
    public event OnUpdateHUD OnUpdateTimeText;
    public event OnUpdateHUD OnUpdateScore;
    public event OnUpdateHUD OnUpdateLife;

    public float CantVidas
    {
        get
        {
            return cantVidas;
        }
    }
    public float CurrentPlayTime
    {
        get
        {
            return currentPlayTime;
        }
    }
    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        cantVidas = 3;
        currentScore = 0;
        currentPlayTime = maxPlayTime;
    }

    /*void Update()
    {
        currentPlayTime += Time.deltaTime;
    }
    */

    //Desde fixedUpdate se ejecuta en todos los procesadores a la misma velocidad, por tanto siempre nos asegura que sea igual para cada dispositivo
    void FixedUpdate()
    {
        currentPlayTime -= Time.fixedDeltaTime;
        OnUpdateTimeText();
        
        //Termina tiempo Partida
        if (currentPlayTime <= 0)
        {
            EndGame();
        }
    }
    public void EnemyHitted()
    {
        //UpdateCurrentScore(100);
    } 
    public void CivilHitted()
    {
        //UpdateCurrentScore(-200);
    }
 
    public void PlayerHitted()
    {
        TakeDamage();
    }
    public void UpdateCurrentScore(int points)
    {
        //Sumo puntuacion
        currentScore += points;

        //Evento para que se actualice el Punto 
        OnUpdateScore();
    }
    //Cuando un enemigo nos dispare antes de desaparecer
    void TakeDamage()
    {
        cantVidas--;
        //Event
        OnUpdateLife();
        //CheckStillAlive
        if (cantVidas <= 0)
        {
            EndGame();
        }
    }
    //Metodo por si hacemos mecánica de curacion
    public void HealLife()
    {
        cantVidas++;
        //Event
        OnUpdateLife();
    }

    void EndGame()
    {
        DataScore.Instance.CheckHighScore(currentScore);
    }

}
