using System.Collections;
using UnityEngine;

public class CookEmotions : MonoBehaviour
{
    public bool IsAfraid { get; set; }
    public bool IsHurt { get; set; }
    public bool IsHappy { get; set; }
    public bool IsLooser { get; set; }

    private bool _canChangeEmotion = true;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite _afraidSprite; // �� ����
    [SerializeField] private Sprite _hurtSprite; // �����
    [SerializeField] private Sprite _happySprite; // ������
    [SerializeField] private Sprite _loseSprite; 
    [SerializeField] private Sprite _defaultSprite;

    private void Update()
    {
        if (IsLooser)
        {
            _canChangeEmotion = false;
            _renderer.sprite = _loseSprite;
        }
        if (_canChangeEmotion)
        {
            if (IsHurt)
            {
                StartCoroutine(HurtRoutine());
            }
            else if (IsAfraid)
            {
                _renderer.sprite = _afraidSprite;
            }
            else
            {
                if (IsHappy)
                {
                    _renderer.sprite = _happySprite;
                }
                else
                {
                    _renderer.sprite = _defaultSprite;
                }
            }
        }
    }

    private IEnumerator HurtRoutine()
    {
        IsHurt = false;
        _canChangeEmotion = false;
        _renderer.sprite = _hurtSprite;
        yield return new WaitForSeconds(0.5f);
        _canChangeEmotion = true;
    }
}
