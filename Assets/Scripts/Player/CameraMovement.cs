using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 10;
    float mouseSpeed = 250;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float yMouse = Input.GetAxis("Mouse ScrollWheel");
        Vector2 movement = new Vector2(0, y);
        Vector2 mouseMovement = new Vector2(0, yMouse);
        transform.Translate(movement * speed * Time.deltaTime);
        transform.Translate(mouseMovement * mouseSpeed * Time.deltaTime);
    }
}
