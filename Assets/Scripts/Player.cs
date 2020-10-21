using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 5f, ySpeed = 5f;
    [Tooltip("In m")][SerializeField] float horizontalRange = 5f, yMin = -3f, yMax = 3f;
    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;
    [Tooltip("Small value to correct apparent roll due to perspective")][SerializeField] float positionRollFactor = 2f;

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
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = Input.GetAxis("Vertical") * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float rollDueToPerspectiveCorrection = transform.localPosition.x * transform.localPosition.y * positionRollFactor;
        float roll = Input.GetAxis("Horizontal") * controlRollFactor + rollDueToPerspectiveCorrection;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
