using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private CookEmotions _emotions;
    [SerializeField] private Text _scoreText;
    [SerializeField] private ScoreBar _scoreBar;
    [SerializeField] private Text _phraseText;
    [SerializeField] private GameObject _recordHighlight;

    [Space]
    [SerializeField] private string[] _phrases;

    private int _highScore;
    private int _score;
    private bool _needToSendEmotion = true;

    public int Score => _score;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("record");
    }

    public void StartScoring()
    {
        StartCoroutine(ScoreRoutine());
        _scoreBar.Activate();
    }

    private IEnumerator ScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _score++;
            _scoreText.text = _score.ToString();
            if (_score > _highScore && _needToSendEmotion)
            {
                _needToSendEmotion = false;
                _emotions.IsHappy = true;
                _recordHighlight.SetActive(true);
            }

            if (_score % 10 == 0)
            {
                StartCoroutine(ShowPhrase());
            }
        }
    }

    private IEnumerator ShowPhrase()
    {
        string phrase = _phrases[Random.Range(0, _phrases.Length)];
        _phraseText.text = phrase;
        _phraseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        _phraseText.gameObject.SetActive(false);
    }
}
