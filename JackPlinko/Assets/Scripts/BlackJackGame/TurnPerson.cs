using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPerson : MonoBehaviour
{
    private bool _isThisPersonTurn;

    public System.Action OnTurnChange;

    public bool IsThisPersonTurn
    {
        get
        {
            return _isThisPersonTurn;
        }
        set
        {
            _isThisPersonTurn = value;

            OnTurnChange?.Invoke();
        }
    }


    protected TurnController TurnController;

    public bool IsReadyForEnd;

    [SerializeField]
    protected Hand MyHand;

    [SerializeField]
    protected TMPro.TMP_Text NumbersText;

    public virtual void Initialize(TurnController turnController)
    {
        foreach (var item in MyHand.MyCards)
        {
            item.gameObject.transform.parent = null;
            item.gameObject.SetActive(false);
        }

        MyHand.MyCards.Clear();

        TurnController = turnController;

        MyHand.AddCard();
        MyHand.AddCard();
    }

    public int GetCardsCount()
    {
        int count = 0;
        foreach (var item in MyHand.MyCards)
        {
            count +=item.cardCount;
        }

        return count;
    }

}
