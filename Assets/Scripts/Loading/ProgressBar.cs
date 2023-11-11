using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * _rotationSpeed);
    }
}
