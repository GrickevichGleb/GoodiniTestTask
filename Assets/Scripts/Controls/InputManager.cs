using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public event Action<Vector2> OnUserInput;
        
    [SerializeField] private Joystick joystick;
    [SerializeField] private TouchPanel touchPanel;
    
    // Input Settings 
    [Space] 
    [SerializeField] private Transform lookCamera;
    [SerializeField] private bool normalizeInput;
    [SerializeField] private bool invertXinput;
    [SerializeField] private bool invertYinput;
    [SerializeField] private float _sensX;
    [SerializeField] private float _sensY;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
    }

    
    void Start()
    {
        touchPanel.OnTouchMove += OnTouchPanelMoveHandler;
    }


    void LateUpdate()
    {
        // Check if player using joystick
        if (joystick.Direction != Vector2.zero)
            InvokeOnUserInput(joystick.Direction, _sensX, _sensY, true, false);
    }
    
    // If player got input from panel
    private void OnTouchPanelMoveHandler(Vector2 touchInput)
    {
        InvokeOnUserInput(touchInput, _sensX, _sensY, false, true);
    }

    private void InvokeOnUserInput(Vector2 input, float sensX, float sensY, bool invertX, bool invertY)
    {
        Vector2 rotation = normalizeInput ? input.normalized : input;
        rotation.x *= Time.deltaTime * sensX;
        rotation.y *= Time.deltaTime * sensY / 180f;
        
        rotation.x *= invertX ? -1f : 1f;
        rotation.y *= invertY ? -1f : 1f;

        OnUserInput?.Invoke(rotation);
    }
}
