using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public List<Sprite> _myImages;

    public Image slotImage;

    public float delayBeforeStart;

    public float delay;

    private float currentTime;

    public int currentIndex = 0;

    public bool IsStopped;

    private void Update()
    {
        if (IsStopped)
        {
            return;
        }

        if (currentTime < 0)
        {
            currentIndex++;

            if (currentIndex >= _myImages.Count)
            {
                currentIndex = 0;
            }

            currentTime = delay;

            slotImage.sprite = _myImages[currentIndex];
        }

        currentTime -= Time.deltaTime;

    }

    public void SetImage(int index)
    {
        IsStopped = true;

        currentIndex = index;

        slotImage.sprite = _myImages[index];
    }

    public void RollStart()
    {
        IsStopped = false;
        currentIndex = Random.Range(0, _myImages.Count);
        //currentTime = delayBeforeStart;
    }







}
