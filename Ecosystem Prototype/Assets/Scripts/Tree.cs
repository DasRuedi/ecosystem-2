using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float leafSpawnTime = 0;
    public float leafSpawnRate = 5;

    [SerializeField] private GameObject leafSpawn;

    [SerializeField] Transform leafParent;


    public int leafOffSpring = 3;

    public static int leafStartPopulation = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leafSpawnTime += Time.deltaTime;

        if (leafSpawnTime >= leafSpawnRate)
        {
            leafSpawnRate = Random.Range(10, 30);

            for (int i = 0; i < leafOffSpring; i++)
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                Instantiate(leafSpawn, position, Quaternion.Euler(rotation), leafParent);

            }
            leafSpawnTime = 0;
        }
    }
}
