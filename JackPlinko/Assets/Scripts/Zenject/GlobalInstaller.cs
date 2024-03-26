using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerData _playerData = null;

    public override void InstallBindings()
    {
        _playerData = SaveManager.Load<PlayerData>(StaticFields.PLAYER_DATA);

        Container.BindInterfacesAndSelfTo<PlayerData>().FromInstance(_playerData).AsSingle();

    }
    private void OnApplicationQuit()
    {
        SaveManager.Save(StaticFields.PLAYER_DATA, _playerData);
    }

}
