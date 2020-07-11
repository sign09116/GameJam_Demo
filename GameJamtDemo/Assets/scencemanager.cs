using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scencemanager : MonoBehaviour
{
    public static scencemanager instance;
    [SerializeField] Button startbutton;
    public Button RePlaybutton;

    public GameObject ball;
    [SerializeField] CanvasGroup canvasGroup;

    public bool isplay=false;
    private void Awake()
    {
        instance = this;
    }
   
    void createBall()
    {
          GameObject temp  =Instantiate(ball, Camera.main.transform.position,Camera.main.transform.rotation);
        temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y, 1f);
    }
   public void createBlocks(GameObject blockprefab)
    {
        Instantiate(blockprefab, Camera.main.transform.position, Camera.main.transform.rotation);
    }
    public void PlayGame() 
    {
        startbutton.gameObject.SetActive(false);
           isplay = true;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;
        createBall();
    }
    public void RePlay() 
    {
        SceneManager.LoadScene(0);
    
    }
   
   
}
