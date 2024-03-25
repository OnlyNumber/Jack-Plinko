using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlHand : TurnPerson
{

    private void Awake()
    {
        MyHand.OnAddingCard += ChangeText;
    }

    public void ChangeText()
    {
        int currentCount = 0;

        foreach (var item in MyHand.MyCards)
        {
            currentCount += item.cardCount;
        }

        NumbersText.text = currentCount.ToString();

        //Debug.Log("PlayerControlHand text change");

    }

    public void AddCard()
    {
        if(!IsThisPersonTurn)
        {
            return;
        }

        MyHand.AddCard();

        TurnController.NextPerson();
    }

    public void SkipReady()
    {
        if (!IsThisPersonTurn)
        {
            return;
        }

        IsReadyForEnd = true;
        TurnController.NextPerson();

    }



}
