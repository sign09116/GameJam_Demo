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
    [SerializeField] Button RePlaySoundbutton;
    public int Count;
    [SerializeField] Text Counttext;
    public GameObject ball;
    [SerializeField] CanvasGroup canvasGroup;
    public List<GameObject> BlockList = new List<GameObject>();
    public bool isplay=false;
    float timer = 0;
    GameObject myBlock;
    [SerializeField] AudioSource aud;
   public List<AudioClip> audlist = new List<AudioClip>();
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        startbutton.gameObject.SetActive(true);
        RePlaybutton.gameObject.SetActive(false);
        RePlaySoundbutton.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (BlockList.Count < 1)
        {
            startbutton.interactable = false;
        }
        else 
        {
            startbutton.interactable = true; 
        }
        if (Input.GetMouseButtonDown(1))
        {
            myBlock.transform.rotation *= Quaternion.AngleAxis(-45f, transform.forward);
        }
        if (isplay==true)
        {
            timer+=Time.deltaTime;
        }
        if (timer > 30)
        {
            pasueGame();
        }
        
    }
    void createBall()
    {
        Vector2 pos = new Vector2(Camera.main.transform.position.x + Random.Range(0f, 1f), Camera.main.transform.position.y + Random.Range(0f, 1f));
        Quaternion rot = Quaternion.Euler(0f, 0f, Random.Range(-90, 90));
          GameObject temp  =Instantiate(ball, pos, rot);
        temp.GetComponent<Rigidbody2D>().simulated = true;
        temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y, 1f);
    }
    public void createBlocks(GameObject blockprefab)
    {
        
         myBlock = Instantiate(blockprefab, Camera.main.transform.position, Camera.main.transform.rotation);
            BlockList.Add(myBlock);
        
        
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
        RePlaybutton.gameObject.SetActive(false);
        startbutton.gameObject.SetActive(true);
        isplay = false;
        timer = 0;
        SceneManager.LoadScene(0);
    }
    private void LateUpdate()
    {
        Counttext.text = Count.ToString();
    }
    public void pasueGame()
    {
        if (audlist.Count>0)
        {
            RePlaySoundbutton.gameObject.SetActive(true);
        }
            RePlaybutton.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().simulated = false;

    }
    public void ReplaySound() 
    {
        StartCoroutine("PlayMusic");
    }
    IEnumerator PlayMusic() 
    {
        for (int i = 0; i < audlist.Count; i++)
        {
            aud.PlayOneShot(audlist[i]);
            yield return new WaitForSeconds(.5f);
        }
    }

}
