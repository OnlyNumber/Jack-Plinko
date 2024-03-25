using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlHand : TurnPerson
{

    

    private void Awake()
    {
        MyHand.OnAddingCard += ChangeText;

        OnTurnChange += MakeEnemyTurn;

    }

    public override void Initialize(TurnController turnController)
    {
        base.Initialize(turnController);

        MyHand.MyCards[0].SetCloseCard(true);

        TurnController.OnCheckingWin += CheckWin;

    }

    public void CheckWin()
    {
        int currentCount = 0;

        for (int i = 0; i < MyHand.MyCards.Count; i++)
        {
            currentCount += MyHand.MyCards[i].cardCount;
        }

        NumbersText.text = currentCount.ToString();

        MyHand.MyCards[0].SetCloseCard(false);

    }

    public void ChangeText()
    {
        int currentCount = 0;

        for (int i = 1; i < MyHand.MyCards.Count; i++)
        {
            currentCount += MyHand.MyCards[i].cardCount;
        }
        //Debug.Log("Enemy text change");

        NumbersText.text =  "? + " +currentCount.ToString();
    }

    public void MakeEnemyTurn()
    {
        if(!IsThisPersonTurn)
        {
            return;
        }

        if(GetCardsCount() <= 15)
        {
            MyHand.AddCard();
            TurnController.NextPerson();
        }
        else
        {
            IsReadyForEnd = true;
            TurnController.NextPerson();

        }

        Debug.Log("EnemyTurn");


    }

}
