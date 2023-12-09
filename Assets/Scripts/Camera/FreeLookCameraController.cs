using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FreeLookCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cmFreeLookCamera;
    
    private InputManager inputManager;
    
    
    void Start()
    {
        inputManager = InputManager.Instance;
        ListenInput(true);
    }


    public void SetTarget(Transform target)
    {
        cmFreeLookCamera.Follow = target;
        cmFreeLookCamera.LookAt = target;
    }
    
    public void ListenInput(bool flag)
    {
        if (flag)
            inputManager.OnUserInput += OnUserInputHandler;
        else
            inputManager.OnUserInput -= OnUserInputHandler;
    }


    private void OnUserInputHandler(Vector2 input)
    {
        cmFreeLookCamera.m_XAxis.Value += input.x;
        cmFreeLookCamera.m_YAxis.Value += input.y;
    }
}
