using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassMovement : MonoBehaviour
{
    [SerializeField] private float _delay;
    private Rigidbody2D _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // StartCoroutine(MoveCenterOfMass());
    }

    private IEnumerator MoveCenterOfMass()
    {
        while (true)
        {
            _rb.centerOfMass = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            yield return new WaitForSeconds(_delay);
        }
    }
}
