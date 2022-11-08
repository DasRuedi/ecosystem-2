using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivore : MonoBehaviour
{
    public float lifeExpect = 65;
    public float maxLifeExpect = 150;
    public float lifeSpan = 0;
    public float hunger = 0f;
    public float moveSpeed = 1.2f;
    public float currMoveSpeed;
    public float reorientationTime = 0;
    public float hungerThreshold = 20;
    public float starveThreshold = 100;

    public GameObject CurrentTarget = null;

    public bool hungry = false;



    void Start()
    {

    }

    
    void Update()
    {
        lifeSpan += Time.deltaTime;
        reorientationTime += Time.deltaTime;
        hunger += Time.deltaTime * 1.5f;

        Healthbar.naturePoints += Time.deltaTime * 0.3f;

        currMoveSpeed = moveSpeed;

        if (hunger >= hungerThreshold)
        {
            hungry = true;

            if (CurrentTarget != null)
            {
                currMoveSpeed = 4;
                transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, currMoveSpeed * Time.deltaTime);
            }
            else
            {
                currMoveSpeed = 3;
                transform.Translate(0, 0, currMoveSpeed * Time.deltaTime);

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
            transform.Translate(0, 0, currMoveSpeed * Time.deltaTime);


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
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<Herbivore>(out Herbivore herbivore) || collision.TryGetComponent<SmallHerbivore>(out SmallHerbivore smallHerbivore) || collision.TryGetComponent<RunningBird>(out RunningBird runningBird))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = collision.gameObject;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Herbivore>(out Herbivore herbivore) || collision.TryGetComponent<SmallHerbivore>(out SmallHerbivore smallHerbivore) || collision.TryGetComponent<RunningBird>(out RunningBird runningBird))
        {
            if (CurrentTarget == collision.gameObject)
            {
                CurrentTarget = null;
            }
        } 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Herbivore") || other.gameObject.CompareTag("small herbivore") || other.gameObject.CompareTag("runningBird"))
        {
            if (hungry == true)
            {
                Destroy(other.gameObject);
                hunger = 0;

                if (lifeExpect < maxLifeExpect)
                {
                    lifeExpect += 5f;
                }
            }
        }
    }

}
