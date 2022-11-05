using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raptor : MonoBehaviour
{
    public float lifeExpect = 65;
    public float maxLifeExpect = 200;
    public float lifeSpan = 0;
    public float hunger = 0f;
    public float moveSpeed = 2f;
    public float currMoveSpeed;
    public float reorientationTime = 0;
    public float hungerThreshold = 20;
    public float starveThreshold = 100;
    public float altitude = 1f;

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

        Healthbar.naturePoints += Time.deltaTime * 0.2f;

        currMoveSpeed = moveSpeed;

        if (transform.position.y >= 30)
        {
            altitude = Random.Range(-1f, -5f);
        }

        if (transform.position.y <= 0)
        {
            altitude = Random.Range(1f, 5f);
        }


        if (hunger >= hungerThreshold)
        {
            hungry = true;

            if (CurrentTarget != null)
            {
                currMoveSpeed = 5;
                transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, currMoveSpeed * Time.deltaTime);
            }
            else
            {
                currMoveSpeed = 3;
                transform.Translate(0, altitude * Time.deltaTime, currMoveSpeed * Time.deltaTime);

                if (reorientationTime >= 7)
                {
                    transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                    reorientationTime = 0;
                }
            }

        }

        if (hunger < hungerThreshold)
        {
            hungry = false;
            transform.Translate(0, altitude * Time.deltaTime, currMoveSpeed * Time.deltaTime);


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
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<Bird>(out Bird bird) || collision.TryGetComponent<Herbivore>(out Herbivore herbivore) || collision.TryGetComponent<SmallHerbivore>(out SmallHerbivore smallHerbivore))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = collision.gameObject;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Bird>(out Bird bird) || collision.TryGetComponent<Herbivore>(out Herbivore herbivore) || collision.TryGetComponent<SmallHerbivore>(out SmallHerbivore smallHerbivore))
        {
            if (CurrentTarget == collision.gameObject)
            {
                CurrentTarget = null;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bird") || other.gameObject.CompareTag("Herbivore") || other.gameObject.CompareTag("small herbivore"))
        {
            if (hungry == true)
            {
                Destroy(other.gameObject);
                hunger = 0;

                if (lifeExpect < maxLifeExpect)
                {
                    lifeExpect += 3f;
                }
            }
        }
    }
}
