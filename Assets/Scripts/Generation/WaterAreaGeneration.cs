using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterAreaGeneration : MonoBehaviour
{
    [SerializeField] GameObject waterArea;
    [SerializeField] GameObject waterParent;
    float randomY;
    float randomX;
    int randomSpawnAmount;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnAmount = Random.Range(50, 125);
        for (int i = 0; i < randomSpawnAmount; i++)
        {
            randomY = Random.Range(-10, -1000);
            randomX = Random.Range(-19.4f, 19.4f);
            GameObject water = Instantiate(waterArea, new Vector3(randomX, randomY, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            water.transform.parent = waterParent.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
