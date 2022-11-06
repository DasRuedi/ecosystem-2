using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPatches : MonoBehaviour
{
    public float witherTime = 0;
    public float witherLimit = 100;
    public bool withering = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Ground.stone == true)
        {
            witherTime += Time.deltaTime;

            if (withering == false)
            {
                witherLimit = Random.Range(10, 90);
                withering = true;
            }
        }

        if (Ground.stone == false)
        {
            witherTime = 0;

            if (withering == true)
            {
                withering = false;
            }
        }



        if (witherTime >= witherLimit)
        {
            Destroy(gameObject);
            Debug.Log("tree died");
        }
    }
}
