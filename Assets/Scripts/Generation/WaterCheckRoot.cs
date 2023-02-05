using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheckRoot : MonoBehaviour
{
    public float waterFromAreas;
    List<int> waterAreaAmount = new List<int>();
    int waterAreaLocal;

    [SerializeField] GameObject pointsManagerScriptObject;
    PointsManager pointsManager;

    // Start is called before the first frame update
    void Start()
    {
        pointsManager = pointsManagerScriptObject.GetComponent<PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        waterAreaLocal += 1;
        waterAreaAmount.Add(waterAreaLocal);
        Debug.Log("There is a root in me!");
    }

    public void CalcWaterFromAreas()
    {
        pointsManager.waterAmount += waterAreaAmount.Count;
    }
}
