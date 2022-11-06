using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusTree : MonoBehaviour
{
    public float flowerSpawnTime = 0;
    public float flowerSpawnRate = 5;

    [SerializeField] private GameObject flowerSpawn;

    [SerializeField] Transform flowerParent;

    public int flowerOffSpring = 1;

    public static int flowerStartPopulation = 5;

    public int maxFlower = 1;
    public int currFlower;

    public float witherTime = 0;
    public float witherLimit = 100;
    public bool withering = false;

    void Update()
    {
        currFlower = (flowerParent.transform.childCount);


        if (Ground.sand == false)
        {
            witherTime += Time.deltaTime;

            if (withering == false)
            {
                if (Ground.grass == true)
                {
                    witherLimit = Random.Range(5, 60);
                    withering = true;
                }
                if (Ground.stone == true)
                {
                    witherLimit = Random.Range(5, 90);
                    withering = true;
                }
            }

        }

        if (Ground.sand == true)
        {
            witherTime = 0;

            if (withering == true)
            {
                withering = false;
            }

            if (currFlower < maxFlower)
            {
                flowerSpawnTime += Time.deltaTime;

                if (flowerSpawnTime >= flowerSpawnRate)
                {
                    flowerSpawnTime = Random.Range(90, 300);

                    for (int i = 0; i < flowerOffSpring; i++)
                    {
                        Vector3 position = new Vector3(transform.position.x, 11, transform.position.z);
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(flowerSpawn, position, Quaternion.Euler(rotation), flowerParent);

                    }
                    flowerSpawnTime = 0;
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
