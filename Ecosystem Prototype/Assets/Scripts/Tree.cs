using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float leafSpawnTime = 0;
    public float leafSpawnRate = 5;

    [SerializeField] private GameObject leafSpawn;

    [SerializeField] Transform leafParent;

    public int leafOffSpring = 1;

    public static int leafStartPopulation = 5;

    public float leaves;

    public int maxLeaves = 5;
    public int currLeaves;

    public float witherTime = 0;
    public float witherLimit = 100;
    public bool withering = false;

    void Start()
    {
        
    }

    void Update()
    {

        currLeaves = (leafParent.transform.childCount);

        if (Ground.grass == false)
        {
            witherTime += Time.deltaTime;

            if (withering == false)
            {
                if (Ground.sand == true)
                {
                    witherLimit = Random.Range(15, 60);
                    withering = true;
                }
                if (Ground.stone == true)
                {
                    witherLimit = Random.Range(5, 30);
                    withering = true;
                }
            }
            
        }

        if (Ground.grass == true)
        {
            witherTime = 0;

            if (withering == true)
            {
                withering = false;
            }

            if (currLeaves <= maxLeaves)
            {
                leafSpawnTime += Time.deltaTime;

                if (leafSpawnTime >= leafSpawnRate)
                {
                    leafSpawnRate = Random.Range(10, 30);
                    leafOffSpring = Random.Range(1, 3);

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

        if (witherTime >= witherLimit)
        {
            Destroy(gameObject);
            Debug.Log("tree died");
        }
        

    }
}
