using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ContainerClick : MonoBehaviour,IPointerClickHandler
{
    public List<CubeTrigger> Cubes=new List<CubeTrigger>();
    public List<ContainerPosition> Positions=new List<ContainerPosition>();

    public int CubeNumber=0;

    public ContainerData containerData;
    
    private GameManager gameManager;

    private void Start() 
    {
        gameManager=FindObjectOfType<GameManager>();
        
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
        if(containerData.IsUp)
            DownLastCube();
        else
            UpLastCube();
        
    }

    private void UpLastCube()
    {
        int lastNumber=Cubes.Count;
        Cubes[lastNumber-1].transform.DOMoveY(3,0.2f);
        containerData.IsUp=true;
        gameManager.TempCube=Cubes[lastNumber-1].transform;
    }

    private void DownLastCube()
    {
        if(CubeNumber<4)
        {
            gameManager.TempCube.transform.DOMoveX(gameObject.transform.position.x,0.5f);
            for (int i = 0; i < Positions.Count; i++)
            {
                if(!Positions[i].isFull)
                {
                    gameManager.TempCube.transform.DOMoveY(Positions[i].transform.position.y,0.5f);
                }
            }
            containerData.IsUp=false;
        }
        
    }

}
