using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadZone : MonoBehaviour
{
    public static DeadZone instance;
    #region 單例
    private void Awake()
    {
     
        instance = this;
    }
    #endregion
   public bool inDeadZone = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.CompareTag("Block"))
        {
            inDeadZone = true;
            spriteRenderer.enabled = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.collider.CompareTag("Block"))
        {
            inDeadZone = false;
            spriteRenderer.enabled = false;
        }
    }
   
}
