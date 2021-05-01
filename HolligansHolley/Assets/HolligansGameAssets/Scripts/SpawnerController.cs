using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] public List<SitiosSpawneables> SpawnPoints = new List<SitiosSpawneables>();

    [SerializeField] Transform[] PuntosSpawn;
    [SerializeField] GameObject[] PersonTypes;
    bool isFull = false;

    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 10f;

    GameObject obj;

    int cantEnemy = 0;
    [SerializeField] int cantMaxEnemy = 6;
    // Start is called before the first frame update
    void Start()
    {
        isFull = false;
        StartCoroutine(SpawnPeople());
    }
    /*
    // Update is called once per frame
    void Update()
    {
        if (!isFull)
        {
            if (cantEnemy <= cantMaxEnemy)
            {
                StartCoroutine(SpawnPeople());

            }       

        }

        if (isFull)
        {
            StartCoroutine(DelayFullPeople());
        }
    }
    */

    IEnumerator SpawnPeople()
    {
        while (!isFull)
        {
            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);

            CheckEmptySpawn();
            //CheckEmptySpawn();
        }
    }
    
    IEnumerator DelayFullPeople()
    {
        float delay = 3f;
        yield return new WaitForSeconds(delay);
        
        isFull = false;
    }

    void CheckEmptySpawn()
    {
        int nextPointToSpawn = Mathf.RoundToInt(Random.Range(0, SpawnPoints.Count));
        if (PuntosSpawn[nextPointToSpawn].childCount == 0)
        {
            Instantiate(PersonTypes[(Random.Range(0, PersonTypes.Length))], PuntosSpawn[nextPointToSpawn]);
            print("LETS GOOO INSTANCEEEE");
        }

    }

}
[System.Serializable]
public class SitiosSpawneables
{
    [SerializeField] public GameObject SpawnPoint;
    public bool isEmpty;
}