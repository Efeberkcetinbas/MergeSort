using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstaceable : MonoBehaviour
{
   float st = 0;
    internal float interval = 3;
    internal bool canStay=false;
    internal bool canInteract = true;
    internal bool canDamageToPlayer=true;
    internal string interactionTag = "Cube";

    void OnTriggerEnter(Collider other)
    {
        if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            StartInteractWithEnemy(other.GetComponent<CubeTrigger>());
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            InteractWithEnemy(other.GetComponent<CubeTrigger>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == interactionTag)
        {
            InteractionExit(other.GetComponent<CubeTrigger>());
        }
    }

    void StartInteractWithEnemy(CubeTrigger Cube)
    {
        DoAction(Cube);
    }

   

    void InteractWithEnemy(CubeTrigger Cube)
    {
        st += Time.deltaTime;
        if (st > interval && canStay)
        {
            ResetProgress();
            DoAction(Cube);
        }
    }
    internal virtual void ResetProgress()
    {
        st = 0;
    }
    internal virtual void InteractionExit(CubeTrigger Cube)
    {
        st = 0;
    }
    internal virtual void DoAction(CubeTrigger Cube)
    {
        throw new System.NotImplementedException();
    }

    
    internal void StopInteract()
    {
        canInteract = false;
    }
    internal void StartInteract()
    {
        canInteract = true;
    }
}
