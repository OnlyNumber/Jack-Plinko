using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool IsReady;

    [SerializeField]
    private Transform _cardPosition;

    [SerializeField]
    private CardsDealing _cardsDealing;

    public List<Card> MyCards = new List<Card>();

    public System.Action OnAddingCard;

    [ContextMenu("AddCard")]
    public void AddCard()
    {
        Card transfer = _cardsDealing.GetRandomCardFromPool();

        transfer.transform.SetParent(_cardPosition);

        MyCards.Add(transfer);

        OnAddingCard?.Invoke();
    }



}
