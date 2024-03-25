using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;


public class CoeficientSquare : MonoBehaviour
{
    [SerializeField]
    private float _coeficient;

    [SerializeField]
    private TMP_Text _coeficientText;

    [SerializeField]
    private BallSpawner _ballSpawner;

    private void Start()
    {
        _coeficientText.text = _coeficient.ToString();
    }

    

    public void Initialzie(BallSpawner ballSpawner)
    {
        _ballSpawner = ballSpawner;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            _ballSpawner.SetRewardWithCoeficient(_coeficient, collision.gameObject.GetComponent<Rigidbody2D>());

            Destroy(collision.gameObject);
        }
        
    }

}
