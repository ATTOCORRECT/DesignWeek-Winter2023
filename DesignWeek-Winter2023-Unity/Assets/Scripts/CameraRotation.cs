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

    int[] targetRotation = { 0, 90, 180, 270 };
    int  targetRotationIndex = 0;

    private void Start()
    {
        currentEulerAngles = mCamera.transform.eulerAngles;
        targetEulerAngles = currentEulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentEulerAngles);
        //Debug.Log(targetEulerAngles);
        //Debug.Log(y);
        currentEulerAngles = new Vector3(0, Mathf.LerpAngle(currentEulerAngles.y, targetRotation[targetRotationIndex], 0.1f),0);

        if (Mathf.Abs(Mathf.DeltaAngle(currentEulerAngles.y, targetRotation[targetRotationIndex])) < 0.1f)
        {
            currentEulerAngles.y = targetRotation[targetRotationIndex];
        }

        mCamera.transform.eulerAngles = currentEulerAngles;

        if (Mathf.Abs(Mathf.DeltaAngle(currentEulerAngles.y, targetRotation[targetRotationIndex])) > 1)
        {
            leftButton.GetComponent<Button>().interactable = false;
            rightButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            leftButton.GetComponent<Button>().interactable = true;
            rightButton.GetComponent<Button>().interactable = true;
        }
    }

    public void RotateCameraLeft()
    {
        targetRotationIndex--;
        targetRotationIndex = (int)mod(targetRotationIndex, 4);
    }

    public void RotateCamerRight()
    {
        targetRotationIndex++;
        targetRotationIndex = (int)mod(targetRotationIndex, 4);
    }

    IEnumerator RotateLeft()
    {
        yield return null;
    }

    float mod(float x, float m) // i hate C# why do i even have to do this
    {
        return (x % m + m) % m;
    }
}
