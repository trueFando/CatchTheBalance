using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private int _price;
    
    [Header("Sprites")]
    [SerializeField] private Sprite _enabledSprite;
    [SerializeField] private Sprite _disabledSprite;

    [Space]
    [SerializeField] private Image _cellImage;
    [SerializeField] private Button _itemButton;
    [SerializeField] private Text _priceText;

    private bool _selected;

    private void Start()
    {
        UpdateItemInfo();
    }

    public void UpdateItemInfo()
    {
        _selected = _index == PlayerPrefs.GetInt("selected_item");

        if (PlayerPrefs.GetInt($"item_{_index}_enabled") != 0)
        {
            _cellImage.sprite = _enabledSprite;
            _itemButton.interactable = true;
            if (_selected)
            {
                _priceText.text = "Selected";
            }
            else
            {
                _priceText.text = "Select";
            }
        }
        else
        {
            _priceText.text = _price.ToString();
            if (PlayerPrefs.GetInt("stars") >= _price)
            {
                _cellImage.sprite = _enabledSprite;
                _itemButton.interactable = true;
            }
            else
            {
                _cellImage.sprite = _disabledSprite;
                _itemButton.interactable = false;
            }
        }

        _itemButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        bool own = PlayerPrefs.GetInt($"item_{_index}_enabled") != 0;
        if (own)
        {
            _selected = true;
            PlayerPrefs.SetInt("selected_item", _index);
            _priceText.text = "Selected";
        }
        else
        {
            bool enoughMoney = PlayerPrefs.GetInt("stars") >= _price;
            if (enoughMoney)
            {
                PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars") - _price); // потратили деньги
                PlayerPrefs.SetInt($"item_{_index}_enabled", 1); // записали
                PlayerPrefs.SetInt("selected_item", _index); // выбрали
                _priceText.text = "Selected";
                FindObjectOfType<Shop>().DisplayStars();
            }
        }
        FindObjectOfType<Shop>().UpdateAllItems();
    }

}
