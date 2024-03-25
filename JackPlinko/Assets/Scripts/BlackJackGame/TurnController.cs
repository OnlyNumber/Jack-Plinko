using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurnController : MonoBehaviour
{


    public List<TurnPerson> turnPeople;

    private int currentPersonIndex = 0;

    public System.Action OnCheckingWin;

    public PanelControl WinPanelControl;

    public PanelControl LosePanelControl;

    private PlayerData playerData;

    [SerializeField]
    private CardsDealing _dealer;

    [SerializeField]
    private Card _rewardCard;

    [SerializeField]
    private GameObject _rewardCoin;

    [SerializeField]
    private TMPro.TMP_Text _rewardCoinText;

    private void Start()
    {
        foreach (var item in turnPeople)
        {
            item.Initialize(this);
        }

        turnPeople[0].IsThisPersonTurn = true;

    }

    [Inject]
    public void Initialize(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public void NextPerson()
    {
        turnPeople[currentPersonIndex].IsThisPersonTurn = false;


        currentPersonIndex++;

        Debug.Log(currentPersonIndex + " " + turnPeople.Count);


        if (currentPersonIndex == turnPeople.Count)
        {
            if (CheckReady())
            {
                CheckWin();
            }
            else
            {
                currentPersonIndex = 0;
                turnPeople[0].IsThisPersonTurn = true;
            }

            foreach (var item in turnPeople)
            {
                item.IsReadyForEnd = false;
            }
        }
        else
        {
            turnPeople[currentPersonIndex].IsThisPersonTurn = true;
        }

    }

    public void CheckWin()
    {
        int winIndex = 0;

        OnCheckingWin?.Invoke();

        if ((turnPeople[0].GetCardsCount() > turnPeople[1].GetCardsCount() && turnPeople[0].GetCardsCount() <= 21) || (turnPeople[0].GetCardsCount() <= 21 && turnPeople[1].GetCardsCount() > 21))
        {
            WinPanelControl.SetPanel(true);

            GetReward();
        }
        else
        {
            LosePanelControl.SetPanel(true);
        }
    }

    public void GetReward()
    {
        bool isAllCardsOpen = true;
        int index = 0;

        int rewardCoin = 0;

        _rewardCard.gameObject.SetActive(false);
        _rewardCoin.SetActive(false);


        foreach (var item in playerData.Cards)
        {
            if (item == 0)
            {
                isAllCardsOpen = false;
                break;
            }
            index++;
        }

        if(isAllCardsOpen)
        {
            _rewardCoin.SetActive(true);

            rewardCoin = Random.Range(10, 20) * 5;

            _rewardCoinText.text = " + " + rewardCoin;
        }
        else
        {
            playerData.Cards[index] = 1;

            _rewardCard.gameObject.SetActive(true);

            _rewardCard.Initialize(_dealer.GetCardInfo(index),CardSuit.none);
        
        }



    }


    public void Restart()
    {
        foreach (var item in turnPeople)
        {
            item.Initialize(this);
        }

        currentPersonIndex = 0;

        turnPeople[0].IsThisPersonTurn = true;
    }

    public bool CheckReady()
    {
        foreach (var item in turnPeople)
        {
            if (item.IsReadyForEnd == false)
            {
                return false;
            }
        }

        return true;
    }


}
