using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;

public class TouchPanel : MonoBehaviour, IPointerMoveHandler
{
    [SerializeField] private Camera ControlPanelCamera;

    public event Action<Vector2> OnTouchMove;
    
    private Vector2 deltaVec = new Vector2(0f, 0f);
    void Start()
    {
        
    }

    
    void Update()
    {
         
    }

   
    public void OnPointerMove(PointerEventData eventData)
    {
        OnTouchMove?.Invoke(eventData.delta.normalized);
    }
}
