using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public RectTransform rectTransform;

    public float speed;

    private void Update()
    {
        rectTransform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

}
