using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CoinManager : MonoBehaviour
{
    int coins;
    [SerializeField]
    TextMeshProUGUI _textCoins;
    [SerializeField]
    RectTransform _rectTransformImageCoin;
    [SerializeField]
    RectTransform _rectTransformTextCoin;
    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        _textCoins.text = coins.ToString();
    }
    public void SumCoins()
    {
        coins = coins + 1;
        _textCoins.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
        print("Coins: " + coins);
        StartCoroutine(AnimationGUI());
    }
    IEnumerator AnimationGUI()
    {
        _rectTransformImageCoin.DOAnchorPosX(0, 0.5f).SetEase(Ease.InBack);
        _rectTransformTextCoin.DOAnchorPosY(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(5);
        _rectTransformImageCoin.DOAnchorPosX(-170, 0.5f).SetEase(Ease.OutBack);
        _rectTransformTextCoin.DOAnchorPosY(150, 0.5f).SetEase(Ease.OutBack);


    }
}
