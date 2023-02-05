using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterAreaGeneration : MonoBehaviour
{
    [SerializeField] GameObject waterArea;
    float randomY;
    float randomX;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 45; i++)
        {
            randomY = Random.Range(0, -1000);
            randomX = Random.Range(-19.4f, 19.4f);
            Instantiate(waterArea, new Vector3(randomX, randomY, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
