using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.EnemyHitted();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Civil"))
        {
            GameManager.Instance.CivilHitted();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
