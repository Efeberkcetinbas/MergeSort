using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerTrigger : Interactable
{
    [SerializeField] private int requirementNumber;

    private BoxCollider boxCollider;

    public GameData gameData;

    private int oneCube=1;

    private void Start() 
    {
        boxCollider=GetComponent<BoxCollider>();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
        
    }


    internal override void DoAction(CubeTrigger cube)
    {
        //Bu sayede istedigi yere istedigi kadar koyar
        if(!gameData.isGameEnd)
        {
            /*if(requirementNumber==cube.cubeProperties.Number)
            {
                gameData.SuccessContainerNumber++;
            }

            else
            {
                Debug.Log("CUBE NUMBER : " + cube.cubeProperties.Number);
            }*/

            if(oneCube==1)
            {
                gameData.SuccessContainerNumber++;
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
                
                
            }
        }
        
    }

    private void OnMerge()
    {
        StartCoroutine(ActiveBoxCollider());
    }


    private IEnumerator ActiveBoxCollider()
    {
        yield return new WaitForSeconds(FindObjectOfType<LevelRequirementTime>().RequirementTime);
        boxCollider.enabled=true;
        EventManager.Broadcast(GameEvent.OnCheckContainer);
    }
}
