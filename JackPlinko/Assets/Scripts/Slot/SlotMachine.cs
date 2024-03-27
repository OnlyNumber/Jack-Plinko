using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SlotMachine : MonoBehaviour
{
    public List<Slot> slots;

    public PanelControl slotPanel;

    public PanelControl winPanel;

    //public TMPro.TMP_Text coinText;

    private PlayerData player;

    [Inject] public void Initialize(PlayerData player)
    {
        this.player = player;

        player.OnChangeCoin += CheckCoins;

        CheckCoins(player.Coins);
    }

    public void StartRolling()
    {
        if(slots[slots.Count - 1].IsStopped == false)
        {
            return;
        }

        foreach (var item in slots)
        {
            item.RollStart();
        }

        StartCoroutine(StopRoll());
    }

    public void CheckCoins(float coins)
    {
        if (coins < 10)
        {
            slotPanel.SetPanel(true);
        }
    }

    IEnumerator StopRoll()
    {
        yield return new WaitForSeconds(2);

        int index = Random.Range(0, 4);

        slots[0].SetImage(index);
        
        if(Random.Range(0,100) > 35)
        {
            slots[1].SetImage(index);
        }
        else
        {
            slots[1].SetImage(Random.Range(0,4));

        }


        if (Random.Range(0, 100) > 35)
        {
            slots[2].SetImage(index);
        }
        else
        {
            slots[2].SetImage(Random.Range(0, 4));
        }

        for (int i = 3; i < slots.Count; i++)
        {
            slots[i].SetImage(Random.Range(0, 4));
        }

        if(slots[0].currentIndex == slots[1].currentIndex && slots[0].currentIndex == slots[2].currentIndex)
        {
            player.TryChangeValueCoin(100);
            winPanel.SetPanel(true);
        }


        
    }

    private void OnDestroy()
    {
        player.OnChangeCoin -= CheckCoins;

    }


}
