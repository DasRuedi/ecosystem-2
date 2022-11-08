using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apex : MonoBehaviour
{
    public float lifeExpect = 40;
    public float maxLifeExpect = 300;
    public float lifeSpan = 0;
    public float hunger = 0f;
    public float moveSpeed = 1f;
    public float currMoveSpeed;
    public float reorientationTime = 0;
    public float hungerThreshold = 10;
    public float starveThreshold = 50;

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

        Healthbar.naturePoints += Time.deltaTime * 1f;

        currMoveSpeed = moveSpeed;

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
                transform.Translate(0, 0, currMoveSpeed * Time.deltaTime);

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
            transform.Translate(0, 0, currMoveSpeed * Time.deltaTime);


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
        if (collision.TryGetComponent<Herbivore>(out Herbivore herbivore) || collision.TryGetComponent<SmallHerbivore>(out SmallHerbivore smallHerbivore) || collision.TryGetComponent<Carnivore>(out Carnivore carnivore) || collision.TryGetComponent<TallHerbivore>(out TallHerbivore tallHerbivore) || collision.TryGetComponent<RunningBird>(out RunningBird runningBird) || collision.TryGetComponent<HugeHerbivore>(out HugeHerbivore hugeHerbivore))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = collision.gameObject;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Herbivore>(out Herbivore herbivore) || collision.TryGetComponent<SmallHerbivore>(out SmallHerbivore smallHerbivore) || collision.TryGetComponent<Carnivore>(out Carnivore carnivore) || collision.TryGetComponent<TallHerbivore>(out TallHerbivore tallHerbivore) || collision.TryGetComponent<RunningBird>(out RunningBird runningBird) || collision.TryGetComponent<HugeHerbivore>(out HugeHerbivore hugeHerbivore))
        {
            if (CurrentTarget == collision.gameObject)
            {
                CurrentTarget = null;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Herbivore") || other.gameObject.CompareTag("small herbivore") || other.gameObject.CompareTag("Carnivore") || other.gameObject.CompareTag("tall herbivore") || other.gameObject.CompareTag("runningBird") || other.gameObject.CompareTag("hugeHerbivore"))
        {
            if (hungry == true)
            {
                Destroy(other.gameObject);
                hunger = 0;

                if (lifeExpect < maxLifeExpect)
                {
                    lifeExpect += 10f;
                }
            }
        }
    }
}
