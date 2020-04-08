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
    [SerializeField] 
    TextMeshProUGUI _timerText;
    [SerializeField]
    GameObject _gameObjecttimeSubstracted;
    void Start()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        currentTime = _startTime;
    }

    void Update()
    {
        CountDown();
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
        //Obtener los componentes
        RectTransform _rectTransformTimeSubstracted = _gameObjecttimeSubstracted.GetComponent<RectTransform>();
        TextMeshProUGUI _textTimeSubstracted = _gameObjecttimeSubstracted.GetComponent<TextMeshProUGUI>();

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
    void ResetTextTimeSubstracted()
    {

    }

}
