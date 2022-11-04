using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] int offspringRate;
    [SerializeField] Transform parent;

    public float time = 0;
    public static int plantPopulation = 50;
    public float spawnRate = 3;
    public float existenceTime = 0;


    public bool extinct = false;

    void Start()
    {
        for (int i = 0; i < plantPopulation; i++)
        {
            Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

            Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
        }
    }

    void Update()
    {
        time += Time.deltaTime;



        if (plantPopulation >= 1)
        {
            if (Healthbar.naturePoints >= 10)
            {
                if (Input.GetKeyDown("space"))
                {
                    for (int i = 0; i < offspringRate; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                        Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
                        Debug.Log("Plant spawned for 10 nature Points");
                        Healthbar.naturePoints -= 10f;
                    }

                }
            }


            
        }

        if (plantPopulation > 0)
        {
            existenceTime += Time.deltaTime;
        }
        if (plantPopulation <= 0 && extinct == false)
        {
            Debug.Log("Plants went extinct after " + existenceTime + "Seconds");
            extinct = true;
        }

        

    }

}
