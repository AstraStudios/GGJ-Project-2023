using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    // money basics: sunlight: 10/5 :water

    [SerializeField] TMP_Text plantAmountText;
    [SerializeField] TMP_Text sunlightAmountText;
    [SerializeField] TMP_Text waterAmountText;
    [SerializeField] TMP_Text sunlightSpendAmountText;
    [SerializeField] TMP_Text waterSpendAmountText;

    float ambientWater; // add constantly
    float ambientSunlight; // add constantly
    int sunlightSpendAmount;
    int waterSpendAmount;
    int plantAmount;
    float waterAmount;


    public float totalMoney;

    GameObject[] numOfPlantsInScene;
    RootsManager rootsManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        rootsManagerScript = gameObject.GetComponent<RootsManager>();
        sunlightSpendAmount = 0;
        waterSpendAmount = 0;
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
        ambientSunlight += 1.5f * plantAmount * Time.deltaTime;
        sunlightAmountText.text = Mathf.RoundToInt(ambientSunlight).ToString();
    }

    void WaterCalc()
    {
        // calculate water from holes and ambient
        ambientWater += .5f * Time.deltaTime;
        waterAmount = ambientWater - waterSpendAmount; // add water from holes later
        waterAmountText.text = Mathf.RoundToInt(waterAmount).ToString();
    }

    void LengthCalc()
    {
        // 1 sunlight every meter
        Debug.Log(rootsManagerScript.currentRootLength);
        sunlightSpendAmount = Mathf.RoundToInt(rootsManagerScript.currentRootLength / 2);
        waterSpendAmount = sunlightSpendAmount / 2;
        waterAmountText.text = Mathf.RoundToInt(waterSpendAmount).ToString();
        sunlightSpendAmountText.text = Mathf.RoundToInt(sunlightSpendAmount).ToString();
    }
}
