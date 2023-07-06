using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ContainerClick : MonoBehaviour,IPointerClickHandler
{
    public List<CubeTrigger> Cubes=new List<CubeTrigger>();

    public int MaxCapacity=4;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
        UpLastCube();
    }

    private void UpLastCube()
    {
        int lastNumber=Cubes.Count;
        Cubes[lastNumber-1].transform.DOMoveY(3,0.2f);
    }
}
