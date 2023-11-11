using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _shopCanvas;
    
    [SerializeField] private Text _starsCountText;
    [SerializeField] private Text _bestText;

    private void Start()
    {
        Application.targetFrameRate = 144;
        Screen.orientation = ScreenOrientation.Portrait;
        _starsCountText.text = PlayerPrefs.GetInt("stars").ToString();
        _bestText.text = "Best " + PlayerPrefs.GetInt("record").ToString();
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetInt("how_to_play") == 0)
        {
            PlayerPrefs.SetInt("how_to_play", 1);
            SceneManager.LoadScene("How To Play");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void OpenShop()
    {
        _mainCanvas.SetActive(false);
        _shopCanvas.SetActive(true);
    }

    public void OpenMain()
    {
        _shopCanvas.SetActive(false);
        _mainCanvas.SetActive(true);
    }
}
