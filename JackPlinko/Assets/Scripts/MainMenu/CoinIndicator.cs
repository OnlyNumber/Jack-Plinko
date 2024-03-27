using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField]
    private List<TMP_Text> _coinTextList;

    private PlayerData player;

    [Inject] public void Initialize(PlayerData playerData)
    {
        playerData.OnChangeCoin += ShowCoin;

        player = playerData;

        ShowCoin(playerData.Coins);
    }

    public void ShowCoin(float coin)
    {
        foreach (var item in _coinTextList)
        {
            item.text = ((int)coin).ToString();
        }
    }

    [ContextMenu("AddCoins")]
    public void AddCoins()
    {
        player.TryChangeValueCoin(200);
    }

    [ContextMenu("DecreaceCoins")]
    public void DecreaceCoins()
    {
        player.TryChangeValueCoin(-10);
    }

    private void OnDestroy()
    {
        player.OnChangeCoin -= ShowCoin;

    }

}
