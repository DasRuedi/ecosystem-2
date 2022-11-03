using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivore : MonoBehaviour
{
    public float lifeExpect = 40;
    public float maxLifeExpect = 150;
    public float lifeSpan = 0;
    public float hunger = 0f;
    public float moveSpeed = 1.2f;
    public float reorientationTime = 0;
    public float reproductionTime = 0;
    public float hungerThreshold = 20;
    public float starveThreshold = 100;

    public GameObject CurrentTarget = null;

    public bool hungry = false;
    public bool adult = false;
    public static bool baby = false;



    void Start()
    {

    }

    
    void Update()
    {
        lifeSpan += Time.deltaTime;
        reorientationTime += Time.deltaTime;
        hunger += Time.deltaTime * 1.5f;
        reproductionTime += Time.deltaTime;

        CarnivoreSpawner.carnivorePoints += Time.deltaTime * 0.3f;

        if (hunger >= hungerThreshold)
        {
            hungry = true;

            if (CurrentTarget != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(0, 0, (-moveSpeed * 2) * Time.deltaTime);

                if (reorientationTime >= 7)
                {
                    transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                    reorientationTime = 0;
                }
            }
            
        }
        
        if(hunger < hungerThreshold)
        {
            hungry = false;
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime);


            if (reorientationTime >= 2)
            {
                transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                reorientationTime = 0;
            }
        }




        if (lifeSpan >= lifeExpect || hunger >= 100f)
        {
            Destroy(gameObject);
        }




        if (CurrentTarget == null)
        {
            return;
        }


        if (reproductionTime >= 20)
        {
            adult = true;
        }

        if (adult == true && hungry == false && reproductionTime >= 17)
        {
            baby = true;
            reproductionTime = 0f;
        }
        else
        {
            return;
        }


    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<Herbivore>(out Herbivore herbivore))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = collision.gameObject;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Herbivore>(out Herbivore herbivore))
        {
            if (CurrentTarget == collision.gameObject)
            {
                CurrentTarget = null;
            }
        } 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Herbivore"))
        {
            if (hungry == true)
            {
                Destroy(other.gameObject);
                hunger = 0;

                if (maxLifeExpect < 200)
                {
                    lifeExpect += 10f;
                }
            }
        }
    }

}
