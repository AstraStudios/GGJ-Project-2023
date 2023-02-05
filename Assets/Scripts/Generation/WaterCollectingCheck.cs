using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollectingCheck : MonoBehaviour
{
    public bool collecting = false;
    private CapsuleCollider2D ccollider;

    private void Start()
    {
        ccollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        CircleCollider2D[] rootEnds = GameObject.Find("CollectorParent").GetComponentsInChildren<CircleCollider2D>();
        for (int i = 0; i < rootEnds.Length; i++)
        {
            if (ccollider.IsTouching(rootEnds[i]))
            {
                collecting = true;
            }
        }
    }
}
