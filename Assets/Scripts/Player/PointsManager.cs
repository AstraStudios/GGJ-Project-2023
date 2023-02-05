using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text plantAmountText;
    [SerializeField] TMP_Text sunlightAmountText;
    [SerializeField] TMP_Text waterAmountText;

    float totalRootDistance; // for the ambient soaking
    float ambientWater; // add constantly
    float ambientSunlight; // add constantly
    int plantAmount;
    public int waterFromHoles;
    public float waterAmount;

    public float totalMoney;

    GameObject[] numOfPlantsInScene;

    // Start is called before the first frame update
    void Start()
    {
        waterFromHoles = 0;
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
        // more plants = more sunlight
        numOfPlantsInScene = GameObject.FindGameObjectsWithTag("Plant");
        plantAmount = numOfPlantsInScene.Length;
        plantAmountText.text = plantAmount.ToString();
    }

    void SunlightCalc()
    {
        // Calculate the sunlight per second
        ambientSunlight += 1.5f * plantAmount * Time.deltaTime;
        sunlightAmountText.text = Mathf.RoundToInt(ambientSunlight).ToString();
    }

    void WaterCalc()
    {
        // calculate water from holes and ambient
        ambientWater += .5f * Time.deltaTime;
        waterAmount = ambientWater + waterFromHoles;
        waterAmountText.text = Mathf.RoundToInt(waterAmount).ToString();
    }
}
