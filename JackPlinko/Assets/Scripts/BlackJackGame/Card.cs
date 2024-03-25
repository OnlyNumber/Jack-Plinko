using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    

    public int cardCount;

    public Image CardImage;

    [SerializeField]
    private List<Image> circles;

    [SerializeField]
    private Image _imageSuit;

    [SerializeField]
    private List<Sprite> imagesSuit;

    [SerializeField]
    private Image _imageClosed;

    public void SetCloseCard(bool state)
    {
        _imageClosed.gameObject.SetActive(state);
    }

    public void Initialize(CardInfo cardInfo, CardSuit cardSuit)
    {
        cardCount = 0;

        if (cardSuit == CardSuit.none)
        {
            _imageSuit.gameObject.SetActive(false);
        }
        else
        {
            _imageSuit.gameObject.SetActive(true);

            _imageSuit.sprite = imagesSuit[(int)cardSuit];
        }


        for (int i = 0; i < cardInfo.ActivatedCirles.Count; i++)
        {
            if(cardInfo.ActivatedCirles[i])
            {
                cardCount++;
            }


            circles[i].gameObject.SetActive(cardInfo.ActivatedCirles[i]);
        }


    }
}
