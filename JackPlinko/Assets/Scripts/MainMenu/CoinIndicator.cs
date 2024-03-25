using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField]
    private List<TMP_Text> _coinTextList;
    
    [Inject] public void Initialize(PlayerData playerData)
    {
        playerData.OnChangeCoin += ShowCoin;

        ShowCoin(playerData.Coins);
    }

    public void ShowCoin(float coin)
    {
        foreach (var item in _coinTextList)
        {
            item.text = ((int)coin).ToString();
        }
    }


}
