using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text plantAmountText;
    [SerializeField] TMP_Text sunlightAmountText;
    [SerializeField] TMP_Text waterAmountText;

    // For water detection(please lord work)
    List<GameObject> water = new List<GameObject>();
    Collider2D waterCol2d;

    float totalRootDistance; // for the ambient soaking
    float ambientWater; // add constantly
    float ambientSunlight; // add constantly
    int plantAmount;
    int waterFromHoles;
    public float waterAmount;

    public float totalMoney;

    GameObject[] numOfPlantsInScene;

    // Start is called before the first frame update
    void Start()
    {
        waterFromHoles = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Water").Length; i++)
        {
            water.Add(GameObject.FindGameObjectsWithTag("Water")[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AmountOfPlants();
        SunlightCalc();
        WaterCalc();
    }

    void AmountOfPlants()
    {
        numOfPlantsInScene = GameObject.FindGameObjectsWithTag("Plant");
        plantAmount = numOfPlantsInScene.Length;
        plantAmountText.text = plantAmount.ToString();
    }

    void SunlightCalc()
    {
        ambientSunlight += 1.5f * plantAmount * Time.deltaTime;
        sunlightAmountText.text = Mathf.RoundToInt(ambientSunlight).ToString();
    }

    void WaterCalc()
    {
        ambientWater += .5f * Time.deltaTime;
        waterAmount = ambientWater + waterFromHoles;
        waterAmountText.text = Mathf.RoundToInt(waterAmount).ToString();
    }
}
