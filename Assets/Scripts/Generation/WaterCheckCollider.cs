using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterCheckCollider : MonoBehaviour
{
    [SerializeField] GameObject managerPrefab;
    PointsManager pointsManagerScript;
    Collider2D[] waterCol2D;

    // Start is called before the first frame update
    void Start()
    {
        pointsManagerScript = managerPrefab.GetComponent<PointsManager>();
        Collider2D[] waterCol2D = Physics2D.OverlapCircleAll(transform.position, 3f, -1, -Mathf.Infinity, Mathf.Infinity);
    }

    // Update is called once per frame
    void Update()
    {
        if (waterCol2D != null)
        {
            Debug.Log("Collecting water from a hole!");

        }
    }
}
