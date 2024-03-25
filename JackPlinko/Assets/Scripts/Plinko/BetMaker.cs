using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

public class BetMaker : MonoBehaviour
{
    [SerializeField]
    private int BallsBoard;

    [SerializeField]
    private TMP_InputField _betField;

    [SerializeField]
    private TMP_InputField _ballsField;

    [SerializeField]
    private BallSpawner _ballSpawner;

    private PlayerData playerData;

    [SerializeField]
    private PanelControl BetPanel;

    [SerializeField]
    private float CurrentBet = 0;

    [SerializeField]
    private int CurrentBalls = 0;



    private void Start()
    {
        _betField.onValueChanged.AddListener(delegate { ChangeFromBetInputField(); });

        _ballsField.onValueChanged.AddListener(delegate { ChangeFromBallsInputField(); });

    }

    [Inject]
    private void Initialize(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public void StartGame()
    {
        if(CurrentBet <= 0 || CurrentBalls <= 0 || CurrentBet > playerData.Coins)
        {
            return;
        }

        playerData.TryChangeValueCoin(-CurrentBet);

        BetPanel.SetPanel(false);
        _ballSpawner.Initialize(CurrentBalls, CurrentBet);
        _ballSpawner.IsGame = true;

    }

    public void ChangeFromBetInputField()
    {
        CurrentBet = float.Parse(_betField.text);

        if (CurrentBet < 0)
        {
            CurrentBet = 0;
        }

        if (CurrentBet >= playerData.Coins)
        {
            CurrentBet = playerData.Coins;
        }

        _betField.text = CurrentBet.ToString();

    }

    public void ChangeFromBallsInputField()
    {
        CurrentBalls = int.Parse(_ballsField.text);
        
        if(CurrentBalls < 0)
        {
            CurrentBalls = 0;
        }

        if (CurrentBalls > BallsBoard)
        {
            CurrentBalls = BallsBoard;
        }

        _ballsField.text = CurrentBalls.ToString();

    }

    public void AddBet(float bet)
    {
        Debug.Log("Coins " + playerData.Coins);

        if (CurrentBet + bet < 0)
        {
            return;
        }
        CurrentBet += bet;

        _betField.text = CurrentBet.ToString();
    }

    public void AddBalls(int ball)
    {
        if(CurrentBalls + ball < 0 )
        {
            return;
        }
        CurrentBalls += ball;

        _ballsField.text = CurrentBalls.ToString();
    }


}
