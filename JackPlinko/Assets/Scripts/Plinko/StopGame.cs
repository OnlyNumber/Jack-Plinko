using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StopGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private BallSpawner _ballSpawner;

    private int LifeTimeCount = 1;

    public void Intialize(BallSpawner ballSpawner)
    {
        _ballSpawner = ballSpawner;

        ballSpawner.OnWin += Life;
    }

    public void Life()
    {
        LifeTimeCount--;

        if(LifeTimeCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _ballSpawner.IsGame = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _ballSpawner.OnWin -= Life;

        _ballSpawner.IsGame = true;
        //Destroy(gameObject);

    }
}
