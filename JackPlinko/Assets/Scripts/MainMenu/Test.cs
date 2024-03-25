using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    private PlayerData pla;

    [Inject] public void Initialize(PlayerData player)
    {
        Debug.Log("Test work");

        pla = player;

        pla.TryChangeValueCoin(10);
    }



}
