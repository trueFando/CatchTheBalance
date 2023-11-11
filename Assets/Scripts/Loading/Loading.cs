using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Text _percentText;
    [SerializeField] private float _lifetime;

    private float _percent;

    private void Start()
    {
        SetFrameRate();
        Invoke(nameof(Kill), _lifetime);
        _percentText.text = "0%";
    }

    private void Update()
    {
        _percent = Time.time / _lifetime * 100;
        _percentText.text = ((int)_percent).ToString() + "%";
    }

    private void SetFrameRate()
    {
        Application.targetFrameRate = 144;
    }

    private void Kill()
    {
        SceneManager.LoadScene("Menu");
    }
}
