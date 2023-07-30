using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeTrigger : MonoBehaviour
{
    internal CubeProperties cubeProperties;

    [SerializeField] private CubeProperties cube;

    public GameData gameData;



    private void Awake() 
    {
        cubeProperties=GetComponent<CubeProperties>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        CubeProperties otherCube=other.gameObject.GetComponent<CubeProperties>();


        if(otherCube!=null && cubeProperties.CubeID > otherCube.CubeID)
        {
            if(cubeProperties.Number==otherCube.Number)
            {
                //Debug.Log("HIT : " + cubeProperties.Number);
                //EventManager.Broadcast(GameEvent.OnMergeNumbers);
                //EventManager.Broadcast(GameEvent.OnIncreaseScore);
                
                OnMergeNumbers(cubeProperties.Number);
                Destroy(gameObject);
                Destroy(otherCube.gameObject);
                //Bu objenin basina ne gelirse clone da oyle oluyor.
            }

            else
            {
                if(!gameData.isGameEnd)
                {
                    gameData.isGameEnd=true;
                    EventManager.Broadcast(GameEvent.OnFail);
                    //Buradan GameOvera baglarsin. Game Over Eventini de eklersin
                    //Debug.Log("FAIL");
                }
                
            }
        }
        
    }

    private void OnMergeNumbers(int value)
    {
        CubeProperties cloneCube=Instantiate(cube,transform.localPosition,Quaternion.identity);
        cloneCube.Number=value*2;
        cloneCube.GetComponent<CubeParticle>().ExplosionParticle.Play();
        EventManager.Broadcast(GameEvent.OnMergeTrigger);
        
        for (int i = 0; i < cloneCube.NumberTexts.Length; i++)
        {
            cloneCube.NumberTexts[i].SetText((cloneCube.Number).ToString());
        }

        //Renk olayini da ayarla !!!!
    }

}
