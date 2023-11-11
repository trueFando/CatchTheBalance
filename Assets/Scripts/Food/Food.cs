using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject _fx;
    private bool _isActive = true;

    private GameObject _spawnedFx;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isActive)
        {
            _spawnedFx = Instantiate(_fx, transform.position, Quaternion.identity);
            _isActive = false;
            Invoke(nameof(KillFX), 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            FindObjectOfType<GameLauncher>().OnGameOver();
        }
    }

    private void KillFX()
    {
        Destroy(_spawnedFx);
    }
}
