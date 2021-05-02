using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerActions : MonoBehaviour
{
    AudioSource cmpAudioSource;
    [SerializeField] AudioClip soundShoot, soundWall, soundHitted;
    [SerializeField] float forceImpulse;
    [SerializeField] GameObject prefBullet;



    // Start is called before the first frame update
    void Start()
    {
        cmpAudioSource = GetComponent<AudioSource>();
        GameManager.Instance.OnPlayerHitted += SoundHitted;
    }

    // Update is called once per frame
    void Update()
    {
        if (!XRSettings.enabled)
        {
            //Check inputTeclado
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
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

        cmpAudioSource.PlayOneShot(soundShoot);

        Destroy(bulletFire, 3f);
    }
    void Shoot(Vector3 dirBullet)
    {
        GameObject bulletFire = Instantiate(prefBullet, this.transform.position, this.transform.rotation);

        cmpAudioSource.PlayOneShot(soundShoot);

        Destroy(bulletFire, 3f);
    }

    void SoundHitted()
    {
        cmpAudioSource.PlayOneShot(soundHitted);
    }
}
