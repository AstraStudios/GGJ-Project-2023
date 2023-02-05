using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text plantAmountText;
    [SerializeField] TMP_Text waterAmountText;
    [SerializeField] TMP_Text waterSpendAmountText;
    [SerializeField] TMP_Text notEnoughMoneyText;

    float ambientWater; // add constantly
    float ambientSunlight; // add constantly
    public int waterSpendAmount;
    int plantAmount;
    public int recusrionLevel;
    public float waterAmount;
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
        waterSpendAmount = 0;
        waterAmount = 10;
        plantGrowOnClickScript = growOnClickSystemObject.GetComponent<PlantGrowOnClick>();
    }

    // Update is called once per frame
    void Update()
    {   
        AmountOfPlants();
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

    void WaterCalc()
    {
        // get all of the scripts to see if they are collecting water
        WaterCollectingCheck[] waterHoles = GameObject.Find("WaterParent").GetComponentsInChildren<WaterCollectingCheck>();
        int activeHoles = 0;

        // find the amount that are collecting water
        for (int i = 0; i < waterHoles.Length; i++)
        {
            if (waterHoles[i].collecting)
                activeHoles += 1;
        }

        // calculate water from holes and ambient
        ambientWater = .001f + .03f * rootsManagerScript.totalRootPerimeter * Time.deltaTime;
        waterAmount += activeHoles * .01f;
        waterAmount += ambientWater; // add water from holes later
        waterAmountText.text = Mathf.FloorToInt(waterAmount).ToString();
    }

    void LengthCalc()
    {
        // 1 sunlight every meter
        waterSpendAmount = Mathf.RoundToInt(rootsManagerScript.currentRootLength * 1.5f);
        waterSpendAmountText.text = Mathf.RoundToInt(waterSpendAmount).ToString();
    }

    public void PayForLine()
    {
        Debug.Log("Transcation starting");
        if (waterAmount > waterSpendAmount)
        {
            waterAmount -= waterSpendAmount;
            Debug.Log("Transcation complete!");
        }
        else
        {
            Debug.Log("Not enough money");
            return;            
        }
    }

    public bool PayForTree(PlantLSystem tree)
    {
        recusrionLevel = tree.currentRecusrionLevel;
        priceWater = 15 * recusrionLevel;

        if (waterAmount >= priceWater)
        {
            waterAmount -= priceWater;
            return true;
        }

        return false;
    }   

    public void ShowTreePrice(PlantLSystem tree)
    {
        recusrionLevel = tree.currentRecusrionLevel + 1;
        priceWater = 15 * recusrionLevel;
    }
}
