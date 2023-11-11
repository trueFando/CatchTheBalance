using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrail : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.position -= new Vector3(0f, _speed * Time.deltaTime, 0f);    
    }
}
