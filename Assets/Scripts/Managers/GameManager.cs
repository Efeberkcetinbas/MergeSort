using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;


    [SerializeField] private GameObject FailPanel;
    [SerializeField] private Ease ease;

    [Header("Open/Close")]
    [SerializeField] private GameObject[] closeGameObjects;
    [SerializeField] private GameObject[] openGameObjects;

    [Header("Game Ending")]
    [SerializeField] private GameObject successPanel;
    [SerializeField] private List<GameObject> stars=new List<GameObject>();
    [SerializeField] private Transform successButton;
    [SerializeField] private GameObject failPanel;

    public List<GameObject> destroyGameObjects=new List<GameObject>();




    private void Awake() 
    {
        ClearData();
    }

    private void Start() 
    {
        OpenClose(openGameObjects,true);
    }

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnCheckContainer,OnCheckContainer);
        EventManager.AddHandler(GameEvent.OnSuccess,OnSuccess);
        EventManager.AddHandler(GameEvent.OnSuccessUI,OnSuccessUI);
        EventManager.AddHandler(GameEvent.OnFail,OnFail);
        EventManager.AddHandler(GameEvent.OnFailUI,OnFailUI);
        EventManager.AddHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnCheckContainer,OnCheckContainer);
        EventManager.RemoveHandler(GameEvent.OnSuccess,OnSuccess);
        EventManager.RemoveHandler(GameEvent.OnSuccessUI,OnSuccessUI);
        EventManager.RemoveHandler(GameEvent.OnFail,OnFail);
        EventManager.RemoveHandler(GameEvent.OnFailUI,OnFailUI);
        EventManager.RemoveHandler(GameEvent.OnNextLevel,OnNextLevel);
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
    }
    
    
    
    public void OpenClose(GameObject[] gameObjects,bool canOpen)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if(canOpen)
                gameObjects[i].SetActive(true);
            else
                gameObjects[i].SetActive(false);
        }
    }

    void OnIncreaseScore()
    {
        //gameData.score += 50;
        DOTween.To(GetScore,ChangeScore,gameData.score+gameData.increaseScore,0.2f).OnUpdate(UpdateUI);
    }

    private int GetScore()
    {
        return gameData.score;
    }

    private void ChangeScore(int value)
    {
        gameData.score=value;
    }

    private void UpdateUI()
    {
        EventManager.Broadcast(GameEvent.OnUIUpdate);
    }

    //Her Levelde
    private void ChangeContainerNumber()
    {
        gameData.RequirementContainerNumber=FindObjectOfType<LevelRequirementContainer>().RequirementContainerNumber;
    }

    private void OnCheckContainer()
    {
        StartCoroutine(CheckingContainer());
    }

    private void OnMerge()
    {
        ChangeContainerNumber();
    }

    private IEnumerator CheckingContainer()
    {
        yield return new WaitForSeconds(0.1f);
        if(gameData.SuccessContainerNumber==gameData.RequirementContainerNumber)
        {
            if(!gameData.isGameEnd)
            {
                Debug.Log("SUCCESSFULL");
                EventManager.Broadcast(GameEvent.OnSuccess);
                gameData.isGameEnd=true;
            }
            
        }

        else
        {
            if(!gameData.isGameEnd)
            {
                gameData.isGameEnd=true;
                EventManager.Broadcast(GameEvent.OnFail);
                //Buradan GameOvera baglarsin. Game Over Eventini de eklersin
                Debug.Log("FAIL");
            }
            //Debug.Log("NOT WORKING");
        }
    }

    private void OnNextLevel()
    {
        OpenClose(closeGameObjects,false);
        gameData.canPlayerTouch=true;
        gameData.isGameEnd=false;
        gameData.SuccessContainerNumber=0;
        OpenClose(openGameObjects,true);
        ResetScaleStar();
        //ChangeContainerNumber();
        CleanMergeCubes();

    }

    private void CleanMergeCubes()
    {
        for (int i = 0; i < destroyGameObjects.Count; i++)
        {
            Destroy(destroyGameObjects[i]);
        }

        destroyGameObjects.Clear();
    }

    private void OnSuccess()
    {
        StartCoroutine(CallUIEvent(GameEvent.OnSuccessUI));
    }

    private void OnFail()
    {
        StartCoroutine(CallUIEvent(GameEvent.OnFailUI));
    }

    private IEnumerator CallUIEvent(GameEvent gameEvent)
    {
        yield return new WaitForSeconds(1);
        EventManager.Broadcast(gameEvent);
    }

    private void OnSuccessUI()
    {
        successPanel.SetActive(true);
        successPanel.transform.localScale=Vector3.zero;
        
        successPanel.transform.DOScale(Vector3.one,0.5f).OnComplete(()=>{
          successButton.DOScale(Vector3.one*1.5f,0.2f).OnComplete(()=>successButton.DOScale(Vector3.one,0.2f));  
          StartCoroutine(StarScale());
        });
    }

    private IEnumerator StarScale()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            stars[i].transform.DOScale(Vector3.one,0.2f);
        }

        
    }

    private void ResetScaleStar()
    {
        successButton.localScale=Vector3.zero;
        successButton.gameObject.SetActive(false);

        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].transform.localScale=Vector3.zero;
            stars[i].gameObject.SetActive(false);
        }
    }

    private void OnFailUI()
    {
        failPanel.SetActive(true);
        failPanel.transform.localScale=Vector3.zero;
        failPanel.transform.DOScale(Vector3.one,0.5f);
    }

    
    void ClearData()
    {
        gameData.canPlayerTouch=true;
        gameData.isGameEnd=false;
        gameData.SuccessContainerNumber=0;
    }

    
}
