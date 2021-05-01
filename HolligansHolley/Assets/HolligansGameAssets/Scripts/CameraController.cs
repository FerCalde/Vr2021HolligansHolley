using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
    [SerializeField] float camSens = 0.5f;
    Vector3 lastMouse = new Vector3(255, 255, 255);

    // Update is called once per frame
    void Update()
    {
        if (!XRSettings.enabled)
        {
            CameraPosition();
        }

    }

    void CameraPosition()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }
}
