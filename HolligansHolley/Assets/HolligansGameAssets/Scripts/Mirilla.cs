using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirilla : MonoBehaviour
{
    RaycastHit hit;
    GameObject mainCamera;
    [SerializeField] GameObject mira;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
        {
            mira.SetActive(true);
            transform.position = hit.point;
            transform.LookAt(mainCamera.transform.position);
        }
        else
        {
            mira.SetActive(false);
        }
    }
}
