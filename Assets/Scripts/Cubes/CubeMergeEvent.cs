using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMergeEvent : MonoBehaviour
{

    private Rigidbody rb;

    private BoxCollider boxCollider;

    private void Start() 
    {
        rb=GetComponent<Rigidbody>();
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

    private void OnMerge()
    {
        boxCollider.isTrigger=false;
        rb.useGravity=true;
    }
}
