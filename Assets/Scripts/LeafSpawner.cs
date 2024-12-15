using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] leafs;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    float pos1;

    [SerializeField]
    float pos2;

    public static LeafSpawner instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawningLeaves();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLeaf()
    {
        int rand = Random.Range(0, leafs.Length);

        float randomX = Random.Range(pos1, pos2);

        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(leafs[rand], randomPos, transform.rotation);

    }

    IEnumerator SpawnLeaves()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnLeaf();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningLeaves()
    {
        StartCoroutine("SpawnLeaves");
    }

    public void StopSpawningLeaves()
    {
        StopCoroutine("SpawnLeaves");
    }

}
