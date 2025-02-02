using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn",timer,timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySpawn()
    {
        Instantiate(enemyPrefab,new Vector3(Random.Range(-spawnRange,spawnRange),2,Random.Range(-spawnRange,spawnRange)+30), Quaternion.identity);
    }
}
