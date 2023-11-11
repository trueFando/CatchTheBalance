using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    private bool _isActive;
    
    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive)
            transform.Rotate(-new Vector3(0f, 0f, Time.deltaTime * 360));
    }
}
