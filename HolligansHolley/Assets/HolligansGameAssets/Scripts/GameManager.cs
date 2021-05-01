using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TemporalSingleton<GameManager>
{
    int currentScore = 0;

    int cantVidas = 3; //En caso de que queramos que los enemigos disparen y nos mate la tercera bala


    float maxPlayTime = 60f;
    float currentPlayTime = 0f;
    /*  #region Singleton
      public static GameManager Instance;

      void Awake()
      {
          Instance = this;
      }
      #endregion   */


    // Start is called before the first frame update
   
    void Start()
    {
        cantVidas = 3;
        currentScore = 0;
    }

    /*void Update()
    {
        currentPlayTime += Time.deltaTime;
    }
    */

    //Desde fixedUpdate se ejecuta en todos los procesadores a la misma velocidad, por tanto siempre nos asegura que sea igual para cada dispositivo
    void FixedUpdate()
    {
        currentPlayTime += Time.fixedDeltaTime;
        
        //Termina tiempo Partida
        if (currentPlayTime >= maxPlayTime)
        {
            EndGame();
        }
    }

    public void UpdateCurrentScore(int points)
    {
        currentScore += points;
    }
    //Cuando un enemigo nos dispare antes de desaparecer
    public void TakeDamage()
    {
        cantVidas--;

        if (cantVidas <= 0)
        {
            EndGame();
        }
    }
    //Metodo por si hacemos mecánica de curacion
    public void HealLife()
    {
        cantVidas++;
    }

    void EndGame()
    {
        DataScore.Instance.CheckHighScore(currentScore);
    }

}
