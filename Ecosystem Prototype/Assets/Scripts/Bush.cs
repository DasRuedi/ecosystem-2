using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    public float berrySpawnTime = 0;
    public float berrySpawnRate = 5;
    
    [SerializeField] private GameObject berrySpawn;

    [SerializeField] Transform berryParent;


    public int berryOffSpring = 5;

    public static int berryStartPopulation = 5;


    void Start()
    {

    }

    
    void Update()
    {
        berrySpawnTime += Time.deltaTime;

        if (berrySpawnTime >= berrySpawnRate)
        {
            berrySpawnRate = Random.Range(5, 20);

            for (int i = 0; i < berryOffSpring; i++)
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                Vector3 rotation = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

                Instantiate(berrySpawn, position, Quaternion.Euler(rotation), berryParent);

            }
            berrySpawnTime = 0;
        }

        
    }
}
