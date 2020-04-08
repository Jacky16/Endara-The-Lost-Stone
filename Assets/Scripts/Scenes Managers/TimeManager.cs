using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class TimeManager : MonoBehaviour
{
    float currentTime;

    [SerializeField] 
    float _startTime;
    PlayerMovement _playerMovement;

    [Header("GameObjects textos canvas")]

    [SerializeField] 
    GameObject _gameObjectTimer;

    [SerializeField]
    GameObject _gameObjecttimeSubstracted;

    public bool _canSubstractTime;

    //Variables Rectransform
    RectTransform _rectTransformTimeSubstracted;
    RectTransform _rectTransformTime;
    //Variables Texto
    TextMeshProUGUI _timerText;
    TextMeshProUGUI _textTimeSubstracted;
    private void Awake()
    {
        _timerText = _gameObjectTimer.GetComponent<TextMeshProUGUI>();
        _rectTransformTime = _gameObjectTimer.GetComponent<RectTransform>();

        _rectTransformTimeSubstracted = _gameObjecttimeSubstracted.GetComponent<RectTransform>();
        _textTimeSubstracted = _gameObjecttimeSubstracted.GetComponent<TextMeshProUGUI>();

        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Start()
    {
        currentTime = _startTime;
        _timerText.text = currentTime.ToString("0");
        SetCanSubstractTime(false);
    }

    void Update()
    {
        if (_canSubstractTime)
        {
            CountDown();
        }
        
    }
    public void CountDown()
    {
        currentTime -= Time.deltaTime;
        _timerText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            _playerMovement.PlayerDead();
        }
    }
    public void ResetTime()
    {
        currentTime = _startTime;
    }
    public void SubstractTime(float timeToSubstract)
    {
        //Aginar el texto al TextTimeSubstracted
        _textTimeSubstracted.text = "-" + timeToSubstract.ToString("0");
        currentTime -= timeToSubstract;

        //Poner el alpha 1
        Color alpha = Color.white;
        alpha.a = 1;
        _textTimeSubstracted.color = alpha;

        //Colocar el texto TimeSubstracted en su posicion original y su escala
        _rectTransformTimeSubstracted.anchoredPosition = new Vector2(0, -126.28f);
        _rectTransformTimeSubstracted.localScale = new Vector2(1, 1);

        //Shake Time text
        RectTransform _rectTransformTimeText = _timerText.GetComponent<RectTransform>();
        _rectTransformTimeText.DOShakeAnchorPos(1f, 10);

        //Hacer la animacion del texto
        Sequence textSequence = DOTween.Sequence();
        textSequence.Append(_rectTransformTimeSubstracted.DOAnchorPosY(-215, 2)); //Movimiento Y
        textSequence.Join(_textTimeSubstracted.DOColor(Color.clear, 2)); //Alpha a 0
        textSequence.Join(_rectTransformTimeSubstracted.DOScale(Vector2.zero, 2));//Escala a 0
       
    }
    public void SetCanSubstractTime(bool b)
    {
        _canSubstractTime = b;
        if (_canSubstractTime)
        {
            _rectTransformTime.DOAnchorPosY(-70, 1);
        }
        else
        {
            _rectTransformTime.DOAnchorPosY(70, 1);

        }

        _canSubstractTime = b;
    }

}
