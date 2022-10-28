using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] int offspringRate;
    [SerializeField] Transform parent;

    public float time = 0;
    public float spawnRate = 8;
    public static int carnivorePopulation = 1;
    public float existenceTime = 0;

    public bool extinct = false;

    void Start()
    {
        for (int i = 0; i < carnivorePopulation; i++)
        {
            Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

            Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        
        /*
        if (carnivorePopulation >= 1)
        {
            if (time >= spawnRate)
            {

                for (int i = 0; i < offspringRate; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                    Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
                }



                carnivorePopulation += offspringRate;



                time = 0;
            }
        }
        */

        if (carnivorePopulation > 0)
        {
            existenceTime += Time.deltaTime;
        }
        if (carnivorePopulation <= 0 && extinct == false)
        {
            Debug.Log("Carnivores went extinct after " + existenceTime + "Seconds");
            extinct = true;
        }
    }

}
