using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    AudioSource cmpAudioSource;
    //[SerializeField] AudioClip soundShoot, soundHit;
    [SerializeField] float forceImpulse;
    [SerializeField] GameObject prefBullet;

    // Start is called before the first frame update
    void Start()
    {
        cmpAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {   
        //DireccionNormalizada
        Vector3 dirBullet = this.transform.forward;
        dirBullet.Normalize();
        
        //InstanciarBullet
        GameObject bulletFire = Instantiate(prefBullet, this.transform.position, this.transform.rotation);
        bulletFire.GetComponent<Rigidbody>().AddForce(dirBullet * forceImpulse, ForceMode.Impulse);
       
        //cmpAudioSource.PlayOneShot(soundShoot);

        Destroy(bulletFire, 3f);
    }
    void Shoot(Vector3 dirBullet)
    {
        GameObject bulletFire = Instantiate(prefBullet, this.transform.position, this.transform.rotation);
        
        //cmpAudioSource.PlayOneShot(soundShoot);

        Destroy(bulletFire, 3f);
    }
}
