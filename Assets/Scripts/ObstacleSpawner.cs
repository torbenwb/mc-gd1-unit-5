using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public GameObject[] obstacleInstances;
    public int numberOfInstances = 10;
    public int instanceIndex = 0;

    public float timeToSpawn;
    public float timeToSpawnMin;
    public float timeToSpawnMax;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(timeToSpawnMin, timeToSpawnMax);

        obstacleInstances = new GameObject[numberOfInstances];

        for (int i = 0; i < numberOfInstances; i++)
        {
            obstacleInstances[i] = Instantiate(obstaclePrefab);
            obstacleInstances[i].transform.position = transform.position;
            obstacleInstances[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn <= 0.0f)
        {
            SpawnObstacle();
            timeToSpawn = Random.Range(timeToSpawnMin, timeToSpawnMax);
        }
    }

    void SpawnObstacle()
    {
        obstacleInstances[instanceIndex].SetActive(true);
        obstacleInstances[instanceIndex].transform.position = transform.position;
        instanceIndex++;
        if (instanceIndex == numberOfInstances) instanceIndex = 0;
        
    }
}
