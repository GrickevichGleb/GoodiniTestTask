using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : MonoBehaviour
{
    private Transform _initialTransform;
    private Transform _cameraTransform;
    void Start()
    {
        _initialTransform = transform;
        _cameraTransform = Camera.main.transform;
        InputManager.Instance.OnUserInput += RotateObject;
    }


    private void RotateObject(Vector2 inputRotation)
    {
        Debug.Log(inputRotation);
        transform.Rotate(_cameraTransform.up, inputRotation.x, Space.World);
        transform.Rotate(_cameraTransform.right, inputRotation.y, Space.World);
    }

    private void RotateToInitialPos()
    {
        transform.SetPositionAndRotation(_initialTransform.position, _initialTransform.rotation);
    }
}
