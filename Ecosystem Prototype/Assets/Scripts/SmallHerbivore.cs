using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHerbivore : MonoBehaviour
{
    public float lifeExpect = 50;
    public float maxLifeExpect = 80;
    public float lifeSpan = 0;
    public float hunger = 0;
    public float hungerThreshold = 10;
    public float starveThreshold = 100;
    public float moveSpeed = 3f;
    public float currMoveSpeed;
    public float reorientationTime = 0;


    public GameObject CurrentTarget = null;

    public bool hungry = false;



    void Update()
    {
        lifeSpan += Time.deltaTime;
        reorientationTime += Time.deltaTime;
        hunger += Time.deltaTime * 3f;

        Healthbar.naturePoints += Time.deltaTime * 0.01f;

        currMoveSpeed = moveSpeed;

        if (hunger >= hungerThreshold)
        {
            hungry = true;

            if (CurrentTarget != null)
            {
                currMoveSpeed = 10f;
                transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                currMoveSpeed = 7f;
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);

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
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);


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


    void OnTriggerStay(Collider collision)
    {
        if (collision.TryGetComponent<GrassPatches>(out GrassPatches plant))
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = collision.gameObject;
            }
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<GrassPatches>(out GrassPatches plant))
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

                if (lifeExpect <= maxLifeExpect)
                {
                    lifeExpect += 3f;
                }

            }
        }
    }
}
