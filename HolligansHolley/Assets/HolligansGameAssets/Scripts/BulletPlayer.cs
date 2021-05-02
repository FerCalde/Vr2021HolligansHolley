using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    AudioSource cmpAudiosource;
    [SerializeField]AudioClip soundFail;
    void Start()
    {
        cmpAudiosource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Civil"))
        {
            //GameManager.Instance.EnemyHitted();
            //collision.gameObject.GetComponent<GuyCivil>().SendHittedScored();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        /*else if (collision.gameObject.CompareTag("Civil"))
        {
            //GameManager.Instance.CivilHitted();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }*/
        cmpAudiosource.PlayOneShot(soundFail);
        Destroy(this.gameObject, 0.1f);
    }
}
