using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Image HealthBar;
    public static float naturePoints = 0f;
    public float maxNaturePoints = 300f;
    public float checkPoint;
    public float time = 0;
    public float roundNaturePoints;

    public TMPro.TMP_Text ResourcesUiElement;


    private void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        checkPoint += Time.deltaTime;
        roundNaturePoints = Mathf.RoundToInt(naturePoints);

        HealthBar.fillAmount = naturePoints / maxNaturePoints;


        if (naturePoints >= maxNaturePoints)
        {
            naturePoints = maxNaturePoints;
        }

        if (checkPoint >= 10)
        {
            Debug.Log(roundNaturePoints + " Nature Points from " + (HerbivoreSpawner.currHerbivorePopulation + CarnivoreSpawner.currCarnivorePopulation) + " Animals at " + time + " Seconds");
            checkPoint = 0;
        }

        ResourcesUiElement.text = "Nature Points: " + roundNaturePoints + "/" + maxNaturePoints;
    }
}
