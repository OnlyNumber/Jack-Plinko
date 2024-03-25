using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    [SerializeField]
    private float forcePower;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 direction = transform.position -collision.transform.position ;

        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D transf))
        {
            transf.AddForce(direction.normalized * forcePower);
        }
    }

    
}
