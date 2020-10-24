using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 5f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 5f;
    [Tooltip("In m")] [SerializeField] float horizontalRange = 5f;
    [Tooltip("In m")] [SerializeField] float yMin = -3f;
    [Tooltip("In m")] [SerializeField] float yMax = 3f;
    bool isAlive = true;

    [Header("Position-based stuff")]
    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float positionYawFactor = 5f;
    [Tooltip("Small value to correct apparent roll due to perspective")] [SerializeField] float positionRollFactor = 2f;

    [Header("Control-based stuff")]
    [SerializeField] float controlPitchFactor = -20f;    
    [SerializeField] float controlRollFactor = -20f;
        
    
    void Update()
    {
        if (isAlive)
        {
            MoveShip();
            RotateShip();
        }
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

    public void PlayerDeath() // CALLED BY STRING REFERENCE!!
    {
        isAlive = false;        
    }
}
