using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour
{
    public GameData gameData;
    public void DoMerge()
    {
        EventManager.Broadcast(GameEvent.OnMerge);
        gameData.canPlayerTouch=false;
    }
}
