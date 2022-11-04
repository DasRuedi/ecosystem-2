using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbivoreSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] int offspringRate;
    [SerializeField] Transform parent;
    public GameObject[] aliveHerbivore;

    public float time = 0;
    public float spawnRate = 5;
    public static int herbivoreStartPopulation = 10;
    public static int currHerbivorePopulation;
    public float existenceTime = 0;

    public bool extinct = false;

    void Start()
    {
        for (int i = 0; i < herbivoreStartPopulation; i++)
        {
            Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

            Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
        }
    }

    void Update()
    {
        time += Time.deltaTime;


        aliveHerbivore = GameObject.FindGameObjectsWithTag("Herbivore");
        currHerbivorePopulation = aliveHerbivore.Length;

        if (currHerbivorePopulation <= 50)
        {
            if (Herbivore.baby == true)
            {
                offspringRate = Random.Range(1, 3);

                for (int i = 0; i < offspringRate; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                    Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
                    //Debug.Log("Herbivore Population: " + herbivorePopulation);
                }

                Herbivore.baby = false;
            }
        }

        if (currHerbivorePopulation > 0)
        {
            existenceTime += Time.deltaTime;
        }
        if (currHerbivorePopulation <= 0 && extinct == false)
        {
            Debug.Log("herbivores went extinct after " + existenceTime + "Seconds");
            extinct = true;
        }


    }



}
