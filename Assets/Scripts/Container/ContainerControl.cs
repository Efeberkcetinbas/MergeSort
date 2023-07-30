using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> blocks=new List<GameObject>();



    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnMerge,OnMerge);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnMerge,OnMerge);
    }


    private void OnMerge()
    {
        StartCoroutine(BlockActivity());
    }


    private IEnumerator BlockActivity()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            //0.4 duruma gore direk indirebilirsin veya aralikli sureler ile
            yield return new WaitForSeconds(0.4f);
            blocks[i].SetActive(false);
            EventManager.Broadcast(GameEvent.OnBreakWindow);
        }
    }
}
