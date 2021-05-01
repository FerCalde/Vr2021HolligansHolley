using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyCivil : MonoBehaviour
{
    [SerializeField] float minStayTime = 3f;
    [SerializeField] float maxStayTime = 5f;
    float timeZero = 0f;

    float waitTime;
    [SerializeField] int pointHitted = -200;
    [SerializeField] int pointMissed = 50;
    // Start is called before the first frame update
    void Start()
    {
        timeZero = 0;
        waitTime = Random.Range(minStayTime, maxStayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeZero >= waitTime)
        {
            GameManager.Instance.UpdateCurrentScore(pointMissed);
            Destroy(this.gameObject);
        }
        else
        {
            timeZero += Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BulletPlayer")
        {
            GameManager.Instance.UpdateCurrentScore(pointHitted);
        }
    }
}
