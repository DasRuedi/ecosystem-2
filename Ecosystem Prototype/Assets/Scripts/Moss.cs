using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss : MonoBehaviour
{
    public float lumpSpawnTime = 0;
    public float lumpSpawnRate = 5;

    [SerializeField] private GameObject lumpSpawn;

    [SerializeField] Transform lumpParent;

    public int lumpOffSpring = 1;

    public static int lumpStartPopulation = 5;

    public int maxLump = 1;
    public int currLump;

    public float witherTime = 0;
    public float witherLimit = 100;
    public bool withering = false;

    void Update()
    {
        currLump = (lumpParent.transform.childCount);

        if (Ground.sand == true)
        {
            witherTime += Time.deltaTime;

            if (withering == false)
            {
                witherLimit = Random.Range(10, 30);
                withering = true;
            }
        }

        if (Ground.sand == false)
        {
            witherTime = 0;

            if (withering == true)
            {
                withering = false;
            }
        }


        if (Ground.sand == false)
        {
            witherTime = 0;

            if (withering == true)
            {
                withering = false;
            }

            if (currLump <= maxLump)
            {
                lumpSpawnTime += Time.deltaTime;

                if (lumpSpawnTime >= lumpSpawnRate)
                {
                    lumpSpawnTime = Random.Range(1, 2);
                    lumpOffSpring = Random.Range(1, 5);


                    for (int i = 0; i < lumpOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(transform.position.x - 3f, transform.position.x + 3f), 0, Random.Range(transform.position.z - 3f, transform.position.z + 3f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(lumpSpawn, position, Quaternion.Euler(rotation), lumpParent);

                    }
                    lumpSpawnTime = 0;
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
