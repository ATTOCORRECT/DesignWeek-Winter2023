using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{
    public GameObject mCamera;
    public GameObject leftButton;
    public GameObject rightButton;

    [SerializeField] float rotationSpeed;
    Vector3 targetEulerAngles;
    Vector3 currentEulerAngles;
    [SerializeField] float y;
    //float yAngleModulus;

    bool turnLeft;
    bool turnRight;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentEulerAngles);
        //Debug.Log(targetEulerAngles);
        //Debug.Log(y);
        currentEulerAngles += new Vector3(0, y, 0) * Time.deltaTime * rotationSpeed;
        mCamera.transform.eulerAngles = currentEulerAngles;

        if(turnLeft)
        {
            if (currentEulerAngles.y >= targetEulerAngles.y)
            {
                y = -1;
                leftButton.GetComponent<Button>().interactable = false;
                rightButton.GetComponent<Button>().interactable = false;
            }
            else if (currentEulerAngles.y <= targetEulerAngles.y)
            {
                y = 0;
                turnLeft = false;
                leftButton.GetComponent<Button>().interactable = true;
                rightButton.GetComponent<Button>().interactable = true;
            }
        }
        if(turnRight)
        {
            if (currentEulerAngles.y <= targetEulerAngles.y)
            {
                y = 1;
                leftButton.GetComponent<Button>().interactable = false;
                rightButton.GetComponent<Button>().interactable = false;
            }
            else if (currentEulerAngles.y >= targetEulerAngles.y)
            {
                y = 0;
                turnRight = false;
                leftButton.GetComponent<Button>().interactable = true;
                rightButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void RotateCameraLeft()
    {
        turnLeft = true;
        currentEulerAngles = mCamera.transform.eulerAngles;
        targetEulerAngles = currentEulerAngles + new Vector3(0, -90, 0);
    }

    public void RotateCamerRight()
    {
        turnRight = true;
        currentEulerAngles = mCamera.transform.eulerAngles;
        targetEulerAngles = currentEulerAngles + new Vector3(0, 90, 0);
    }

    IEnumerator RotateLeft()
    {
        yield return null;
    }
}
