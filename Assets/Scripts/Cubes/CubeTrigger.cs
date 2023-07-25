using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeTrigger : MonoBehaviour
{
    private CubeProperties cubeProperties;

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
                Debug.Log("HIT : " + cubeProperties.Number);
                //EventManager.Broadcast(GameEvent.OnMergeNumbers);
                //EventManager.Broadcast(GameEvent.OnIncreaseScore);
                //Destroy(cubeProperties.gameObject);
                //Destroy(otherCube.gameObject);
                OnMergeNumbers(cubeProperties.Number);
            }

            else
            {
                Debug.Log("FAIL");
            }
        }
        
    }

    private void OnMergeNumbers(int value)
    {
        CubeProperties cloneCube=Instantiate(cube,transform.localPosition,Quaternion.identity);
        cloneCube.Number=value*2;
        for (int i = 0; i < cloneCube.NumberTexts.Length; i++)
        {
            cloneCube.NumberTexts[i].SetText((cloneCube.Number).ToString());
        }

        //Renk olayini da ayarla !!!!
    }

}
