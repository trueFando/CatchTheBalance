using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFX : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // трястись
        StartCoroutine(ShakingRoutine());

        // постепенно исчезнуть
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        float a = 1f;
        do
        {
            a -= Time.deltaTime * _fadeSpeed;
            _renderer.color = new Color(1f, 1f, 1f, a);
            yield return null;
        } while (_renderer.color.a > 0f);

        Destroy(gameObject);
    }

    private IEnumerator ShakingRoutine()
    {
        Vector3 startPosition = transform.position;
        while (true)
        {
            transform.position = startPosition + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
