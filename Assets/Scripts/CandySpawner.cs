using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float pos1;

    [SerializeField]
    float pos2;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject[] candies;

    public static CandySpawner instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //SpawnCandy();
        StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, candies.Length);

        float randomX = Random.Range(pos1,pos2);

        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(candies[rand],randomPos , transform.rotation);

    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while(true)
        {
            SpawnCandy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }

}
