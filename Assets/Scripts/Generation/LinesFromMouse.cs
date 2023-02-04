using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesFromMouse : MonoBehaviour
{
    public GameObject lineDrawer;
    private DrawLine drawLineScript;
    private Camera cam;

    private Vector3 lineStart;

    // the points where you will be able to draw a line from. first one is the base of the plant
    List<Vector3> points = new List<Vector3>();
    [SerializeField] Vector3 rootStartPoint;

    // if the user has started makeing a line, set to true
    private bool startedMakingLine = false;

    // get the mouses position in world space. z is always 0
    private Vector3 GetMousePosition()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(pos.x, pos.y, 0);
    }

    // find the closet point to a point. Used to determine where mouse clicks are intended to be
    private Vector3 FindNearestPoint(Vector3 point, List<Vector3> points)
    {
        Vector3 closestPoint = new Vector3(0, 0, 0);
        float closestDistance = Mathf.Infinity;

        // the distance from the point being checked to point
        float distance;

        // for each point see if it is closer than the closet point
        for (int i = 0; i < points.Count; i++)
        {
            distance = Mathf.Pow((point.x - points[i].x), 2) + Mathf.Pow((point.y - points[i].y), 2);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = points[i];
            }
        }

        return closestPoint;
    }


    private void Start()
    {
        cam = Camera.main;
        points.Add(rootStartPoint);
    }

    // Update is called once per frame
    private void Update()
    {
        // stop making the line, it will keep its current state
        if (Input.GetMouseButtonDown(0) && startedMakingLine)
        {
            startedMakingLine = false;

            // add the endpoint to the points list
            points.Add(drawLineScript.end);
        }

        // start making a line
        else if (Input.GetMouseButtonDown(0) && !startedMakingLine)
        {
            // make the line object and get the script
            GameObject line = Instantiate(lineDrawer, new Vector3(0, 0, 0), Quaternion.identity);

            // find where it will make the start
            lineStart = FindNearestPoint(GetMousePosition(), points);

            // get the script and set the start
            drawLineScript = line.GetComponent<DrawLine>();
            drawLineScript.start = lineStart;

            startedMakingLine = true;
        }

        // update the end of the line to be at the cursor
        if (startedMakingLine)
            drawLineScript.end = GetMousePosition();

        
    }
}
