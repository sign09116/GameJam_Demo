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
    Vector2 offset;
    Vector2 targetpoint;
    Vector2 oringlpoint;
    Vector2 curPosition;
    int Dragtime=0;
    bool canDrag = true;
    private void FixedUpdate()
    {
        
        Ballrig.velocity -= new Vector2(Time.deltaTime* speed, Time.deltaTime* speed);
        Debug.Log(Ballrig.velocity);
        
       // Ballrig.transform.position= new Vector2(Mathf.Clamp(transform.position.x, -7.35f, 7.35f), Mathf.Clamp(transform.position.y, -4.48f, 4.48f));

    }
    private void LateUpdate()
    {
        if (Ballrig.velocity == new Vector2(0f, 0f))
        {
            canDrag = false;
            scencemanager.instance.RePlaybutton.gameObject.SetActive(true);
            return;
        }

    }
    private void OnMouseDown()
    {
        oringlpoint = this.transform.position;
          offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
         Dragtime++;
    }
    private void OnMouseDrag()
    {
       if (Dragtime!=1)
       {   
          return;
       }
        if (canDrag==true)
        {
            Vector2 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            curPosition = (Vector2)Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
    private void OnMouseUp()
    {
       
           targetpoint = (curPosition - oringlpoint) * 100f;
        Ballrig.AddForce(targetpoint);

    }
}
