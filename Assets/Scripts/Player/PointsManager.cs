using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{
    // money basics: sunlight: 10/5 :water

    [SerializeField] TMP_Text plantAmountText;
    [SerializeField] TMP_Text sunlightAmountText;
    [SerializeField] TMP_Text waterAmountText;
    [SerializeField] TMP_Text sunlightSpendAmountText;
    [SerializeField] TMP_Text waterSpendAmountText;
    [SerializeField] TMP_Text notEnoughMoneyText;

    float ambientWater; // add constantly
    float ambientSunlight; // add constantly
    public int sunlightSpendAmount;
    public int waterSpendAmount;
    int plantAmount;
    int recusrionLevel;
    public float waterAmount;
    public float sunlightAmount;
    public int priceSunlight;
    public int priceWater;

    public float totalMoney;

    GameObject[] numOfPlantsInScene;
    [SerializeField] GameObject growOnClickSystemObject;
    PlantGrowOnClick plantGrowOnClickScript;
    RootsManager rootsManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        rootsManagerScript = gameObject.GetComponent<RootsManager>();
        sunlightSpendAmount = 0;
        waterSpendAmount = 0;
        waterAmount = 0;
        sunlightAmount = 0;
        ambientWater = 10;
        plantGrowOnClickScript = growOnClickSystemObject.GetComponent<PlantGrowOnClick>();
    }

    // Update is called once per frame
    void Update()
    {   
        AmountOfPlants();
        SunlightCalc();
        WaterCalc();
        LengthCalc();
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
        ambientSunlight += 0.0015f * recusrionLevel * Time.deltaTime;
        sunlightAmount += ambientSunlight;
        sunlightAmountText.text = Mathf.RoundToInt(sunlightAmount).ToString();
    }

    void WaterCalc()
    {
        // calculate water from holes and ambient
        ambientWater += .5f * rootsManagerScript.totalRootPerimeter * Time.deltaTime;
        ambientWater = ambientWater / 2;
        waterAmount += ambientWater; // add water from holes later
        waterAmountText.text = Mathf.RoundToInt(waterAmount).ToString();
    }

    void LengthCalc()
    {
        // 1 sunlight every meter
        sunlightSpendAmount = Mathf.RoundToInt(rootsManagerScript.currentRootLength * 2);
        waterSpendAmount = sunlightSpendAmount / 2;
        waterSpendAmountText.text = Mathf.RoundToInt(waterSpendAmount).ToString();
        sunlightSpendAmountText.text = Mathf.RoundToInt(sunlightSpendAmount).ToString();
    }

    public void PayForLine()
    {
        Debug.Log("Transcation starting");
        if (sunlightAmount > sunlightSpendAmount && waterAmount > waterSpendAmount)
        {
            sunlightAmount -= sunlightSpendAmount;
            waterAmount -= waterSpendAmount;
            Debug.Log("Transcation complete!");
        }
        else
        {
            PlaceText();
        }
    }
    IEnumerator PlaceText()
    {
        for (; ;)
        {
            notEnoughMoneyText.text = "You do not have enough money!";
        }
        yield return new WaitForSeconds(.5f);
    }

    public void PayForTree()
    {
        switch (recusrionLevel)
        {
            case 1:
                priceSunlight += 30;
                priceWater += 15;
                break;
            case 2:
                priceSunlight += 60;
                priceWater += 30;
                break;

        }
    }
}
