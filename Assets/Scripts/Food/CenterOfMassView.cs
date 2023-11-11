using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private void Update()
    {
        transform.position = _rb.worldCenterOfMass;
    }
}
