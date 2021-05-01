using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]public List<SitiosSpawneables> SpawnPoints=new List<SitiosSpawneables>();

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class SitiosSpawneables
{
    [SerializeField]GameObject SpawnPoint;
    bool isEmpty;
}