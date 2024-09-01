using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemiesController : MonoBehaviour
{
    [SerializeField] private GameObject catSmall, catBig;
    private float timeSpawn;
    private float clockSpawn;
    [SerializeField]
    private float range1;
    [SerializeField]
    private float range2;

    void Awake()
    {
        timeSpawn = Random.Range(range1, range2);
        clockSpawn = timeSpawn;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCatSmall();
    }

    private void SpawnCatSmall()
    {
        clockSpawn -= Time.deltaTime;
        if (clockSpawn < 0)
        {
            timeSpawn = Random.Range(range1, range2);
            clockSpawn = timeSpawn;
            GameObject.Instantiate(catSmall, transform.position, Quaternion.identity);
        }

    }

    private void SpawnCatBig()
    {
        Instantiate(catBig, transform.position, Quaternion.identity);
    }
}
