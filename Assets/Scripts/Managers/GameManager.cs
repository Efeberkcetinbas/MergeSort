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
    [SerializeField] private GameObject[] open_close;




    private void Awake() 
    {
        ClearData();
    }

    private void Start() 
    {
        ChangeContainerNumber();
    }

    

    private void OnEnable()
    {
        //EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnCheckContainer,OnCheckContainer);
    }

    private void OnDisable()
    {
        //EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnCheckContainer,OnCheckContainer);
    }
    
    void OnGameOver()
    {
        FailPanel.SetActive(true);
        FailPanel.transform.DOScale(Vector3.one,1f).SetEase(ease);
        playerData.playerCanMove=false;
        gameData.isGameEnd=true;

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
        DOTween.To(GetScore,ChangeScore,gameData.score+gameData.increaseScore,0.25f).OnUpdate(UpdateUI);
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

    private IEnumerator CheckingContainer()
    {
        yield return new WaitForSeconds(0.1f);
        if(gameData.SuccessContainerNumber==gameData.RequirementContainerNumber)
        {
            Debug.Log("SUCCESSFULL");
        }

        else
        {
            Debug.Log("NOT WORKING");
        }
    }

    
    void ClearData()
    {
        gameData.canPlayerTouch=true;
        gameData.isGameEnd=false;
        gameData.SuccessContainerNumber=0;
    }

    
}
