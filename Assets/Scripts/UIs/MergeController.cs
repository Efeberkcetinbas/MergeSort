using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour
{
    public void DoMerge()
    {
        EventManager.Broadcast(GameEvent.OnMerge);
    }
}
