using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerTouchController : MonoBehaviour
{
    private Transform cube;
    private Transform firstCube;
    private Vector3 tempPosition;

    private int touchIndex;
   
    public GameData gameData;

    void Update()
    {
        if(!gameData.isGameEnd && gameData.canPlayerTouch)
            CheckTouch();
    }

    private void CheckTouch()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if(touchIndex==0)
                {
                    if (raycastHit.collider.CompareTag("Cube"))
                    {
                        touchIndex++;
                        firstCube=raycastHit.collider.transform;
                        tempPosition=raycastHit.collider.transform.position;
                        firstCube.DOScale(new Vector3(0.6f,0.6f,0.6f),0.2f);
                        Debug.Log("Index 0ken buraya girdi");
                        return;
                    }
                }

                if(touchIndex==1)
                {
                    if (raycastHit.collider.CompareTag("Cube"))
                    {
                        firstCube.position=raycastHit.collider.transform.position;
                        raycastHit.collider.transform.position=tempPosition;
                        touchIndex=0;
                        Debug.Log("Index 1ken buraya girdi");
                        firstCube.DOScale(new Vector3(0.8f,0.8f,0.8f),0.2f);
                        raycastHit.collider.transform.DOScale(new Vector3(0.6f,0.6f,0.6f),0.2f).OnComplete(()=>raycastHit.collider.transform.DOScale(new Vector3(0.8f,0.8f,0.8f),0.2f));
                        
                        return;

                        //raycastHit.collider.transform.DOLocalRotate(new Vector3(0,360,0),.25f,RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
                    }
                    
                }
                
            }
        }
    }
}
