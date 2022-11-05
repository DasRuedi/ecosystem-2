using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float time = 0;

    [SerializeField] private GameObject grassSpawn;
    [SerializeField] private GameObject bushSpawn;
    [SerializeField] private GameObject treeSpawn;
    [SerializeField] private GameObject herbivoreSpawn;
    [SerializeField] private GameObject carnivoreSpawn;
    [SerializeField] private GameObject birdSpawn;
    [SerializeField] private GameObject tallHerbivoreSpawn;
    [SerializeField] private GameObject raptorSpawn;
    [SerializeField] private GameObject smallHerbivoreSpawn;
    [SerializeField] private GameObject apexSpawn;

    [SerializeField] Transform grassParent;
    [SerializeField] Transform bushParent;
    [SerializeField] Transform treeParent;
    [SerializeField] Transform herbivoreParent;
    [SerializeField] Transform carnivoreParent;
    [SerializeField] Transform birdParent;
    [SerializeField] Transform tallHerbivoreParent;
    [SerializeField] Transform raptorParent;
    [SerializeField] Transform smallHerbivoreParent;
    [SerializeField] Transform apexParent;

    public GameObject[] aliveGrass;
    public GameObject[] aliveBush;
    public GameObject[] aliveTree;
    public GameObject[] aliveHerbivore;
    public GameObject[] aliveCarnivore;
    public GameObject[] aliveBird;
    public GameObject[] aliveTallHerbivore;
    public GameObject[] aliveRaptor;
    public GameObject[] aliveSmallHerbivore;
    public GameObject[] aliveApex;


    public int grassOffSpring = 3;
    public int bushOffSpring = 1;
    public int treeOffSpring = 1;
    public int herbivoreOffSpring;
    public int carnivoreOffSpring;
    public int birdOffSpring;
    public int tallHerbivoreOffSpring;
    public int raptorOffSpring;
    public int smallHerbivoreOffSpring;
    public int apexOffSpring;

    public static int currGrassPopulation;
    public static int currBushPopulation;
    public static int currTreePopulation;
    public static int currHerbivorePopulation;
    public static int currCarnivorePopulation;
    public static int currBirdPopulation;
    public static int currTallHerbivorePopulation;
    public static int currRaptorPopulation;
    public static int currSmallHerbivorePopulation;
    public static int currApexPopulation;
    public static int currGroundAnimalPopulation;

    public float herbivoreSpawnRate;
    public float carnivoreSpawnRate;
    public float birdSpawnRate;
    public float tallHerbivoreSpawnRate;
    public float raptorSpawnRate;
    public float smallHerbivoreSpawnRate;
    public float apexSpawnRate;

    public float herbivoreReproductionTime;
    public float carnivoreReproductionTime;
    public float birdReproductionTime;
    public float tallHerbivoreReproductionTime;
    public float raptorReproductionTime;
    public float smallHerbivoreReproductionTime;
    public float apexReproductionTime;

    public bool herbivoreInit = false;
    public bool carnivoreInit = false;
    public bool birdInit = false;
    public bool tallHerbivoreInit = false;
    public bool raptorInit = false; 
    public bool smallHerbivoreInit = false;
    public bool apexInit = false;


    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;

        reproductionTimes();

        populationCheck();


        Grass();

        Bush();

        Tree();


        HerbivoresInit();
        Herbivores();

        CarnivoresInit();
        Carnivores();

        BirdsInit();
        Birds();

        tallHerbivoresInit();
        tallHerbivores();

        RaptorsInit();
        Raptors();

        smallHerbivoresInit();
        smallHerbivores();

        ApexesInit();
        Apexes();
    }


    public void Grass()
    {
        if (Healthbar.naturePoints >= 10)
        {
            if (Input.GetKeyDown("1"))
            {
                for (int i = 0; i < grassOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                    Instantiate(grassSpawn, position, Quaternion.Euler(rotation), grassParent);

                }
                Debug.Log(grassOffSpring + " patches of Grass spawned for 10 nature Points");
                Healthbar.naturePoints -= 10f;
            }
        }

    }

    public void Bush()
    {
        if (Healthbar.naturePoints >= 20)
        {
            if (Input.GetKeyDown("2"))
            {
                for (int i = 0; i < bushOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                    Instantiate(bushSpawn, position, Quaternion.Euler(rotation), bushParent);

                }
                Debug.Log(bushOffSpring + " bushe spawned for 20 nature Points");
                Healthbar.naturePoints -= 20f;
            }
        }

    }

    public void Tree()
    {
        if (Healthbar.naturePoints >= 30)
        {
            if (Input.GetKeyDown("3"))
            {
                for (int i = 0; i < treeOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, Random.Range(0f, 360f), 0);

                    Instantiate(treeSpawn, position, Quaternion.Euler(rotation), treeParent);

                }
                Debug.Log(treeOffSpring + " Tree spawned for 20 nature Points");
                Healthbar.naturePoints -= 30f;
            }
        }

    }

    public void HerbivoresInit()
    {
        if (herbivoreInit == false)
        {
            if (currGrassPopulation >= 15)
            {
                herbivoreOffSpring = 3;

                for (int i = 0; i < herbivoreOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, 0, 0);

                    Instantiate(herbivoreSpawn, position, Quaternion.Euler(rotation), herbivoreParent);
                    Debug.Log(herbivoreOffSpring + " Herbivores were born");
                }

                herbivoreInit = true;

            }
        } 
    }

    public void Herbivores()
    {
        if (herbivoreInit == true)
        {
            if (currHerbivorePopulation >= 1 && currHerbivorePopulation <= 30)
            {
                if (herbivoreReproductionTime >= 23f)
                {
                    herbivoreOffSpring = Random.Range(1, 5);

                    for (int i = 0; i < herbivoreOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(herbivoreSpawn, position, Quaternion.Euler(rotation), herbivoreParent);
                        Debug.Log(herbivoreOffSpring + " Herbivores were born");
                    }

                    herbivoreReproductionTime = 0;
                }
            }
        }
    }

    public void CarnivoresInit()
    {
        if (carnivoreInit == false)
        {
            if (currHerbivorePopulation >= 8 || currSmallHerbivorePopulation >= 23)
            {
                carnivoreOffSpring = 1;

                for (int i = 0; i < herbivoreOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, 0, 0);

                    Instantiate(carnivoreSpawn, position, Quaternion.Euler(rotation), carnivoreParent);
                    Debug.Log(carnivoreOffSpring + " Carnivores were born");
                }

                carnivoreInit = true;
            }
        }
    }

    public void Carnivores()
    {
        if (carnivoreInit == true)
        {
            if (currCarnivorePopulation >= 1 && currCarnivorePopulation <= 15)
            {
                if (carnivoreReproductionTime >= 37f)
                {
                    carnivoreOffSpring = Random.Range(1, 2);

                    for (int i = 0; i < carnivoreOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(carnivoreSpawn, position, Quaternion.Euler(rotation), carnivoreParent);
                        Debug.Log(carnivoreOffSpring + " Carnivores were born");
                    }

                    carnivoreReproductionTime = 0f;
                }
            }
        }
    }

    public void BirdsInit()
    {
        if (birdInit == false)
        {
            if (currBushPopulation >= 3 && currTreePopulation >= 1)
            {
                birdOffSpring = 5;

                for (int i = 0; i < birdOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 20f), Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, 0, 0);

                    Instantiate(birdSpawn, position, Quaternion.Euler(rotation), birdParent);
                    Debug.Log(birdOffSpring + " birds were born");
                }

                birdInit = true;
            }
        }
    }

    public void Birds()
    {
        if (birdInit == true)
        {
            if (currBirdPopulation >= 1 && currBirdPopulation <= 40)
            {
                if (birdReproductionTime >= 17f)
                {
                    birdOffSpring = Random.Range(3, 7);

                    for (int i = 0; i < birdOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 20f), Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(birdSpawn, position, Quaternion.Euler(rotation), birdParent);
                        Debug.Log(birdOffSpring + " Birds were born");
                    }

                    birdReproductionTime = 0f;
                }
            }
        }


        
    }

    public void tallHerbivoresInit()
    {
        if (tallHerbivoreInit == false)
        {
            if (currTreePopulation >= 5 && currApexPopulation <= 0)
            {
                tallHerbivoreOffSpring = 1;

                for (int i = 0; i < tallHerbivoreOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, 0, 0);

                    Instantiate(tallHerbivoreSpawn, position, Quaternion.Euler(rotation), tallHerbivoreParent);
                    Debug.Log(tallHerbivoreOffSpring + " birds were born");
                }

                tallHerbivoreInit = true;
            }
        }
    }

    public void tallHerbivores()
    {
        if (tallHerbivoreInit == true)
        {
            if (currTallHerbivorePopulation >= 1 && currTallHerbivorePopulation  <= 12 && currApexPopulation <= 0)
            {
                if (tallHerbivoreReproductionTime == 51)
                {
                    tallHerbivoreOffSpring = Random.Range(1, 2);

                    for (int i = 0; i < tallHerbivoreOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(tallHerbivoreSpawn, position, Quaternion.Euler(rotation), tallHerbivoreParent);
                        Debug.Log(tallHerbivoreOffSpring + " tall Herbivores were born");
                    }

                    tallHerbivoreReproductionTime = 0;
                }
            }
        }


        
    }

    public void RaptorsInit()
    {
        if (raptorInit == false)
        {
            if (currTreePopulation >= 1)
            {
                if (currBirdPopulation >= 10 || currHerbivorePopulation >= 7 || currSmallHerbivorePopulation >= 15)
                {
                    raptorOffSpring = 1;

                    for (int i = 0; i < raptorOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 50f), Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(raptorSpawn, position, Quaternion.Euler(rotation), raptorParent);
                        Debug.Log(raptorOffSpring + " Raptors were born");
                    }

                    raptorInit = true;
                }
            }
        }
    }

    public void Raptors()
    {
        if (raptorInit == true)
        {
            if (currRaptorPopulation >= 1 && currRaptorPopulation <= 13)
            {
                if (raptorReproductionTime >= 31)
                {
                    raptorOffSpring = Random.Range(1, 2);

                    for (int i = 0; i < raptorOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 50f), Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(raptorSpawn, position, Quaternion.Euler(rotation), raptorParent);
                        Debug.Log(raptorOffSpring + " Raptors were born");
                    }

                    raptorReproductionTime = 0;
                }
            }
        }


        
    }


    public void smallHerbivoresInit()
    {
        if (smallHerbivoreInit == false)
        {
            if (currGrassPopulation >= 10 && currBushPopulation >= 3)
            {
                smallHerbivoreOffSpring = 5;

                for (int i = 0; i < smallHerbivoreOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, 0, 0);

                    Instantiate(smallHerbivoreSpawn, position, Quaternion.Euler(rotation), smallHerbivoreParent);
                    Debug.Log(smallHerbivoreOffSpring + " small herbivores were born");
                }

                smallHerbivoreInit = true;

            }
        }
    }
    public void smallHerbivores()
    {
        if (smallHerbivoreInit == true)
        {
            if (currSmallHerbivorePopulation >= 1 && currSmallHerbivorePopulation <= 50)
            {
                if (smallHerbivoreReproductionTime == 11)
                {
                    smallHerbivoreOffSpring = Random.Range(4, 9);

                    for (int i = 0; i < smallHerbivoreOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(smallHerbivoreSpawn, position, Quaternion.Euler(rotation), smallHerbivoreParent);
                        Debug.Log(smallHerbivoreOffSpring + " small Herbivores were born");
                    }

                    smallHerbivoreReproductionTime = 0;
                }
            }
        }


        
    }

    public void ApexesInit()
    {
        if (apexInit == false)
        {
            if (currGroundAnimalPopulation >= 25)
            {
                apexOffSpring = 1;

                for (int i = 0; i < apexOffSpring; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                    Vector3 rotation = new Vector3(0, 0, 0);

                    Instantiate(apexSpawn, position, Quaternion.Euler(rotation), apexParent);
                    Debug.Log(apexOffSpring + " Apex was born");
                }

                apexInit = true;

            }
        }
    }

    public void Apexes()
    {
        if (apexInit == true)
        {
            if (currApexPopulation >= 1 && currApexPopulation <= 3)
            {
                if (apexReproductionTime >= 52)
                {
                    apexOffSpring = Random.Range(1, 2);

                    for (int i = 0; i < apexOffSpring; i++)
                    {
                        Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
                        Vector3 rotation = new Vector3(0, 0, 0);

                        Instantiate(apexSpawn, position, Quaternion.Euler(rotation), apexParent);
                        Debug.Log(apexOffSpring + " Apexes were born");
                    }

                    apexReproductionTime = 0;
                }
            }
        }


        
    }

    public void populationCheck()
    {
        aliveGrass = GameObject.FindGameObjectsWithTag("Plant");
        currGrassPopulation = aliveGrass.Length;

        aliveBush = GameObject.FindGameObjectsWithTag("bush");
        currBushPopulation = aliveBush.Length;

        aliveTree = GameObject.FindGameObjectsWithTag("tree");
        currTreePopulation = aliveTree.Length;

        aliveHerbivore = GameObject.FindGameObjectsWithTag("Herbivore");
        currHerbivorePopulation = aliveHerbivore.Length;

        if (currHerbivorePopulation <= 0 && herbivoreInit == true)
        {
            herbivoreInit = false;
        }


        aliveCarnivore = GameObject.FindGameObjectsWithTag("Carnivore");
        currCarnivorePopulation = aliveCarnivore.Length;

        if (currCarnivorePopulation <= 0 && carnivoreInit == true)
        {
            carnivoreInit = false;
        }


        aliveBird = GameObject.FindGameObjectsWithTag("bird");
        currBirdPopulation = aliveBird.Length;

        if (currBirdPopulation <= 0 && birdInit == true)
        {
            birdInit = false;
        }


        aliveTallHerbivore = GameObject.FindGameObjectsWithTag("tall herbivore");
        currTallHerbivorePopulation = aliveTallHerbivore.Length;

        if (currTallHerbivorePopulation <= 0 && tallHerbivoreInit == true)
        {
            tallHerbivoreInit = false;
        }


        aliveRaptor = GameObject.FindGameObjectsWithTag("raptor");
        currRaptorPopulation = aliveRaptor.Length;

        if (currRaptorPopulation <= 0 && raptorInit == true)
        {
            raptorInit = false;
        }


        aliveSmallHerbivore = GameObject.FindGameObjectsWithTag("small herbivore");
        currSmallHerbivorePopulation = aliveSmallHerbivore.Length;

        if (currSmallHerbivorePopulation <= 0 && smallHerbivoreInit == true)
        {
            smallHerbivoreInit = false;
        }

        aliveApex = GameObject.FindGameObjectsWithTag("Apex");
        currApexPopulation = aliveApex.Length;

        if (currApexPopulation <= 0 && apexInit == true)
        {
            apexInit = false;
        }

        currGroundAnimalPopulation = currHerbivorePopulation + currCarnivorePopulation + currTallHerbivorePopulation + currSmallHerbivorePopulation + currApexPopulation;
    }


    public void reproductionTimes()
    {
        if (herbivoreInit == true)
        {
            herbivoreReproductionTime += Time.deltaTime;
        }

        if (carnivoreInit == true)
        {
            carnivoreReproductionTime += Time.deltaTime;
        }
            
        if (birdInit == true)
        {
            birdReproductionTime += Time.deltaTime;
        }
        
        if (tallHerbivoreInit == true)
        {
            tallHerbivoreReproductionTime += Time.deltaTime;
        }
        
        if (raptorInit == true)
        {
            raptorReproductionTime += Time.deltaTime;
        }
        
        if (smallHerbivoreInit == true)
        {
            smallHerbivoreReproductionTime += Time.deltaTime;
        }
        
        if (apexInit == true)
        {
            apexReproductionTime += Time.deltaTime;
        }
        
    }
}
