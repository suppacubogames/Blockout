using UnityEngine;
using System;

public class Floor : MonoBehaviour
{
    public static event Action OnFloorHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            OnFloorHit?.Invoke();
        }
    }
}
