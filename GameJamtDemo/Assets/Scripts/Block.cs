
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource audioSource;
    Vector2 offset;
    Vector2 curPosition;
    float speed = 2f;
    
    private void Update()
    {
        transform.position = new Vector2( Mathf.Clamp(transform.position.x, -7.41f, 5.55f), Mathf.Clamp(transform.position.y, -4.22f, 4.25f));
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
       int range= Random.Range(0, 100);
        if (hit.collider.CompareTag("Player"))
        {
            if (range<50)
            {
                hit.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.one*Random.Range(-1,1)*speed,ForceMode2D.Impulse);      
            }
           
            audioSource.PlayOneShot(clip);
            scencemanager.instance.audlist.Add(clip);
        }
    }
    private void OnMouseExit()
    { float xMin = Random.Range(-2, -3);
        float xMax = Random.Range(1, 3);
        float yMin = Random.Range(1, 3);
        float yMax = Random.Range(3, 4);
        if (DeadZone.instance.inDeadZone==true)
        {
            transform.position = curPosition+new Vector2(Random.Range(xMin, xMax),Random.Range(yMin, yMax));
        }   
    }

}
