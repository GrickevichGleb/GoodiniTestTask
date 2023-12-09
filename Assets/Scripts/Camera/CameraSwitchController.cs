using System.Collections;
using System.Collections.Generic;
using System.Data;
using Cinemachine;
using UnityEngine;

public class CameraSwitchController : MonoBehaviour
{
    [SerializeField] private FreeLookCameraController closeUpCameraController;
    [SerializeField] private FreeLookCameraController aerialCameraController;
    [SerializeField] private GameObject[] targetObjects;

    private GameObject _curentTarget;

    public void SwitchCameraToTarget(int targetIndex)
    {
        if (_curentTarget == targetObjects[targetIndex])
        {
            _curentTarget = null;
            SwitchToAerialCamera();
        }
        else
        {
            _curentTarget = targetObjects[targetIndex];
            SwitchToCloseUpCamera(_curentTarget);
        }
    }
    
    public void SwitchToCloseUpCamera(GameObject target)
    {
        closeUpCameraController.SetTarget(target.transform);
        aerialCameraController.gameObject.SetActive(false);
        // CloseUpCameraController.gameObject.SetActive(true);
        // Adding delay before activating input
        StartCoroutine(TimeDelayCoroutine(2f));
        closeUpCameraController.ListenInput(true);
    }

    public void SwitchToAerialCamera()
    {
        closeUpCameraController.ListenInput(false);
        aerialCameraController.gameObject.SetActive(true);
        // Adding delay before activating input
        StartCoroutine(TimeDelayCoroutine(2f));
        aerialCameraController.ListenInput(true);
    }

    private IEnumerator TimeDelayCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
