using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeSprites : MonoBehaviour
{
    public Material material;

    [ContextMenu("ChangeMaterial")]
    public void ChangeMaterial()
    {
        foreach (var item in FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None))
        {
            item.material = material;
        }
    }
}
