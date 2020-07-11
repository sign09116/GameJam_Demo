using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource audioSource;
    Vector2 offset;
    Vector2 curPosition;
    
    private void Update()
    {
        transform.position = new Vector2( Mathf.Clamp(transform.position.x, -7.35f, 7.35f), Mathf.Clamp(transform.position.y, -4.48f, 4.48f));
    }
    private void OnMouseDown()
    {
       
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
    private void OnMouseDrag()
    {
        if (scencemanager.instance.isplay==false)
        {
            Vector2 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            curPosition = (Vector2)Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

        }
    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            scencemanager.instance.Count++;
            audioSource.PlayOneShot(clip);
            scencemanager.instance.audlist.Add(clip);
        }
    }
    
}
