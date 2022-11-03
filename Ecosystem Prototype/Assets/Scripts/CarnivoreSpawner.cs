using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] int offspringRate;
    [SerializeField] Transform parent;
    public GameObject[] aliveCarnivore;

    public float time = 0;
    public float spawnRate = 8;
    public static int carnivoreStartPopulation = 1;
    public int currCarnivorePopulation;
    public float existenceTime = 0;
    public static float carnivorePoints = 0f;
    public float checkPoint;

    public bool extinct = false;

    void Start()
    {
        for (int i = 0; i < carnivoreStartPopulation; i++)
        {
            Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

            Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        checkPoint += Time.deltaTime;

        aliveCarnivore = GameObject.FindGameObjectsWithTag("Carnivore");
        currCarnivorePopulation = aliveCarnivore.Length;

        if (currCarnivorePopulation <= 10)
        {
            if (Carnivore.baby == true)
            {
                offspringRate = Random.Range(1, 2);

                for (int i = 0; i < offspringRate; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                    Instantiate(objectToBeSpawned, position, Quaternion.Euler(rotation), parent);
                }

                Carnivore.baby = false;
            }
        }

        if (currCarnivorePopulation > 0)
        {
            existenceTime += Time.deltaTime;
        }
        if (currCarnivorePopulation <= 0 && extinct == false)
        {
            Debug.Log("Carnivores went extinct after " + existenceTime + "Seconds");
            extinct = true;
        }

        if (checkPoint >= 10)
        {
            Debug.Log(carnivorePoints + " Carnivore Points from " + currCarnivorePopulation + " Carnivores at " + time + " Seconds");
            checkPoint = 0;
        }
    }

}
