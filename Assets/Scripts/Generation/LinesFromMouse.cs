using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesFromMouse : MonoBehaviour
{
    public GameObject lineDrawer;
    private DrawLine drawLineScript;
    private Camera cam;

    private Vector3 lineStart;
    // if the user has started makeing a line, set to true
    private bool startedMakingLine = false;
    
    private Vector3 GetMousePosition()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(pos.x, pos.y, 0);
    } 

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        // stop making the line, it will keep its current state
        if (Input.GetMouseButtonDown(0) && startedMakingLine)
            startedMakingLine = false;

        // start making a line
        else if (Input.GetMouseButtonDown(0) && !startedMakingLine)
        {
            // make the line object
            lineStart = GetMousePosition();
            GameObject line = Instantiate(lineDrawer, new Vector3(0, 0, 0), Quaternion.identity);

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
