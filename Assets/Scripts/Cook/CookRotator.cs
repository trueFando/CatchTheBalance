using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private bool _isActive;
    private Camera _mainCamera;

    // rotation
    private Vector3 _oldMousePos;

    private void Start()
    {
        _mainCamera = Camera.main;

    }

    private void Update()
    {
        if (_isActive)
        {
            // RotateByScreenSides();
            RotateBySwipe();
        }
    }

    private void RotateBySwipe()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _oldMousePos = Vector3.zero;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 newMousePos = Input.mousePosition;
            if (_mainCamera.ScreenToViewportPoint(newMousePos).y < 0.8f)
            {
                if (_oldMousePos == Vector3.zero)
                {
                    _oldMousePos = newMousePos;
                    return;
                }
                else
                {
                    float distance = newMousePos.x - _oldMousePos.x;
                    transform.Rotate(new Vector3(0f, 0f, -distance * _rotationSpeed * Time.deltaTime));
                    _oldMousePos = newMousePos;
                }
            }
        }
    }

    public void Activate()
    {
        SetActive(true);
    }

    public void Deactivate()
    {
        SetActive(false);
    }

    private void SetActive(bool active) 
    {
        _isActive = active;
    }
}
