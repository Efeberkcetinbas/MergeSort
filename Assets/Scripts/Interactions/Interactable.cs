using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    float st = 0;
    internal float interval = 3;
    internal bool canInteract = true;
    internal string interactionTag = "Cube";

    
    private void OnTriggerEnter(Collider other) 
    {
        if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            StartInteractWithPlayer(other.GetComponent<CubeTrigger>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            ExitInteractWithPlayer(other.GetComponent<CubeTrigger>());
        }
    }
    
    // !!!!!!!!!!!!!!
    //Kaldigi sure boyunca burasi da aktif oluyor
    void OnTriggerStay(Collider other)
    {
        /*if (!canInteract) return;
        if (other.tag == interactionTag)
        {
            InteractWithPlayer(other.GetComponent<Player>());
        }*/
    }
    
    void StartInteractWithPlayer(CubeTrigger cube)
    {
        DoAction(cube);
    }

    void ExitInteractWithPlayer(CubeTrigger cube)
    {
        //InteractionExit(player);
    }

    void InteractWithPlayer(CubeTrigger cube)
    {
        st += Time.deltaTime;
        if (st > interval)
        {
            ResetProgress();
            DoAction(cube);
        }
    }
    //virtuallarin hepsini implemente ediyor
    internal virtual void ResetProgress()
    {
        st = 0;
    }
    internal virtual void InteractionExit(CubeTrigger cube)
    {
        throw new System.NotImplementedException();
    }
    internal virtual void DoAction(CubeTrigger cube)
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
