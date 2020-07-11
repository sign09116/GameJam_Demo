using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{/// <summary>球的鋼體 </summary>
    [SerializeField] Rigidbody2D Ballrig;
    /// <summary>推力的方向 </summary>
   Ray pushpoint;
    [SerializeField] Camera maincameral;
    [SerializeField] float speed=0f;
    private void Start()
    {
        Ballrig.AddRelativeForce(Vector2.up* speed,ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.CompareTag("Wall"))
        {
            scencemanager.instance.pasueGame();
        }
    }
}
