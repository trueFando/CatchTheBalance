using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages;
    private int _index = 0;

    public void Next()
    {
        _pages[_index].SetActive(false);
        _index++;
        if (_index >= _pages.Length)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
