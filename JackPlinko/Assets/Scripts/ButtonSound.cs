using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;

    private void Start()
    {
        bool IsAdded = false;

        Button button = GetComponent<Button>();
        for (int i = 0; i < button.onClick.GetPersistentEventCount(); i++)
        {
            if (button.onClick.GetPersistentMethodName(i) == "SountClip")
            {
                IsAdded = true;
                break;
            }
        }

        if (_clip != null && IsAdded == false)
        {
            button.onClick.AddListener(SountClip);
        }

    }

    [ContextMenu("SountClip")]
    public void SountClip()
    {
        SoundController.Instance.PlayAudioClip(_clip);
    }

}
