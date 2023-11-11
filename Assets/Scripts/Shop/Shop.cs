using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text _starsText;

    private void Start()
    {
        PlayerPrefs.SetInt("item_0_enabled", 1);
        DisplayStars();
    }

    public void DisplayStars()
    {
        _starsText.text = PlayerPrefs.GetInt("stars").ToString();
    }

    public void UpdateAllItems()
    {
        ShopItem[] items = FindObjectsOfType<ShopItem>();
        foreach (var item in items)
        {
            item.UpdateItemInfo();
        }
    }
}
