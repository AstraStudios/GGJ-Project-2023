using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TMP_Text plantAmountText;
    [SerializeField] TMP_Text sunlightAmountText;
    [SerializeField] TMP_Text waterAmountText;

    [SerializeField] WaterCheckRoot waterCheckingScript;

    float totalRootDistance; // for the ambient soaking
    float ambientWater; // add constantly
    int plantAmount;
    public float sunlightAmount;  // add constantly
    public float waterAmount;

    public float totalPlantHealth;

    GameObject[] numOfPlantsInScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmountOfPlants();
    }

    void CheckRootLengthAndAddAmbient()
    {
        // wait for seth root length
    }

    void AmountOfPlants()
    {
        numOfPlantsInScene = GameObject.FindGameObjectsWithTag("Plant");
        plantAmount = numOfPlantsInScene.Length;
        plantAmountText.text = plantAmount.ToString();
    }

    void SunlightCalc()
    {

    }
}
