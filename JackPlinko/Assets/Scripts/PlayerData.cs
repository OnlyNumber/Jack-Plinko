using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float MusicVolume;

    public float ClipVolume;
    
    public float _coin;

    [System.NonSerialized]
    public System.Action<float> OnChangeCoin;

    public float Coins
    {
        set
        {
            _coin = value;

            OnChangeCoin?.Invoke(_coin);
        }

        get
        {
            return _coin;
        }
    }

    public List<int> Cards = new List<int>();

    public List<ListWrapper> PlayerSkins = new List<ListWrapper>();

    public List<int> CurrentSkin = new List<int>();

    public bool IsFirstLog = true;

    public int VolumeClip;

    public int VolumeMusic;

    public PlayerData()
    {
        _coin = 200;

        for (int i = 0; i < (int)PlayerSkinType.Count; i++)
        {
            PlayerSkins.Add(new ListWrapper());
            CurrentSkin.Add(-1);
        }


    }
    
    public bool TryChangeValueCoin(float coins)
    {

        if(coins + Coins < 0)
        {
            return false;
        }

        Coins += coins;

        return true;


    }

    [System.Serializable]
    public class ListWrapper
    {
        public List<bool> list = new List<bool>();
    }

}

public enum PlayerSkinType
{
    background,
    card,
    ball,
    /// <summary>
    /// Count is always must be last member of enum DO NOT CHANGE HIS LAST PLACE, this is not skin type
    /// </summary>
    Count

}
