using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbivore : MonoBehaviour
{
    public float lifeExpect = 60;
    public float maxLifeExpect = 200;
    public float lifeSpan = 0;
    public float hunger = 0;
    public float hungerThreshold = 50;
    public float starveThreshold = 100;
    public float moveSpeed = 1f;
    public float reorientationTime = 0;
    public float reproductionTime = 0;


    public GameObject CurrentTarget = null;

    public bool hungry = false;
    public bool adult = false;
    public static bool baby = false;


    void Awake()
    {
        
    }

    void Start()
    {

    }


    void Update()
    {
        lifeSpan += Time.deltaTime;
        reorientationTime += Time.deltaTime;
        hunger += Time.deltaTime * 3f;
        reproductionTime += Time.deltaTime;

        HerbivoreSpawner.herbivorePoints += Time.deltaTime * 0.1f;


        if (hunger >= hungerThreshold)
        {
            hungry = true;

            if (CurrentTarget != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);

                if (reorientationTime >= 5)
                {
                    transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                    reorientationTime = 0;
                }
            }
        }

        if (hunger < hungerThreshold)
        {
            hungry = false;
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);


            if (reorientationTime >= 2)
            {
                transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                reorientationTime = 0;
            }
        }


        if (lifeSpan >= lifeExpect || hunger >= starveThreshold)
        {
            Destroy(gameObject);
        }


        if (CurrentTarget == null)
        {
            return;
        }

        if (reproductionTime >= 30)
        {
            adult = true;
        }

        if (adult == true && hungry == false && reproductionTime >= 23)
        {
            baby = true;
            reproductionTime = 0f;
        }
        else
        {
            return;
        }


        
    }


    void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<Plants>(out Plants plant))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = collision.gameObject;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Plants>(out Plants plant))
        {
            if (CurrentTarget == collision.gameObject)
            {
                CurrentTarget = null;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            if (hungry == true)
            {
                Destroy(other.gameObject);
                hunger = 0;
                hungry = false;

                PlantSpawner.plantPopulation--;
                if (maxLifeExpect < 200)
                {
                    lifeExpect += 10f;
                }
                
                //Debug.Log("Plant died. new population: " + PlantSpawner.plantPopulation);
            }
        }
    }
}
