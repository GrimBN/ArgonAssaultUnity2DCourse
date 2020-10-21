using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 5f, ySpeed = 5f;
    [SerializeField] float horizontalRange = 5f, yMin = -3f, yMax = 3f;

    void Start()
    {
        
    }
    
    void Update()
    {
        MoveShip();
        RotateShip();
    }

    private void MoveShip()
    {
        float xOffset = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        float yOffset = Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float xPos = Mathf.Clamp(rawXPos, -horizontalRange, +horizontalRange);
        float yPos = Mathf.Clamp(rawYPos, yMin, yMax);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z); 
        //Debug.Log(xOffset + "," + (1f/Time.deltaTime));
    }

    private void RotateShip()
    {
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;
    }
}
