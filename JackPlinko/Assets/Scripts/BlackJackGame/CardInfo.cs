using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo")]
public class CardInfo : ScriptableObject
{
    public int Chance;

    public List<bool> ActivatedCirles;

}


public enum CardSuit
{
    heart,
    rhombus,
    blackHeart,
    cross,
    none
}
