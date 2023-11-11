using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPhysics : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private BombFX _fxObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        foreach (var c in colliders)
        {
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            if (rb)
            {
                Vector3 direction = rb.transform.position - transform.position;
                rb.AddForce(direction * _explosionForce, ForceMode2D.Impulse);
            }

            if (c.transform.parent != null)
            {
                CookEmotions emotions = c.transform.parent.gameObject.GetComponent<CookEmotions>();
                if (emotions)
                {
                    emotions.IsHurt = true;
                }
            }
            
        }
        Instantiate(_fxObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
