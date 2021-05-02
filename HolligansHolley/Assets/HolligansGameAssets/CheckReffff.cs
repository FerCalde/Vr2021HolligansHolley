using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckReffff : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject cb = GameObject.FindObjectOfType<CardboardStartup>().gameObject;
        if (cb != null)
        {
            print(cb.name + " Es CardboardStartup");
        }
        if (cb == null)
        {
            print( "NO ss encontro CardboardStartup");
        }

        GameObject xkd = GameObject.FindObjectOfType<VrModeController>().gameObject;
        if (xkd != null)
        {
            print(xkd.name + " Es VRControll");
        }
        if (xkd == null)
        {
            print("NO ss encontro VRContr");
        }
    }

}
