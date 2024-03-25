using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    public SpriteRenderer Sprite;

    public BallSpawner origin;

    private Vector3 _lastPosition = Vector3.zero;

    private float delay = 3;

    [SerializeField]
    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(_lastPosition == transform.position)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            _lastPosition = transform.position;
            currentTime = 0;
        }


        if(currentTime >= delay)
        {
            origin.ReturnBall(this);

            Destroy(gameObject);
            //return ball
        }
    }

    

}
