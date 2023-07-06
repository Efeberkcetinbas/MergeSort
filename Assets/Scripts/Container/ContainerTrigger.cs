using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerTrigger : Obstaceable
{
    private ContainerClick containerClick;

    private void Start() 
    {
        containerClick=GetComponent<ContainerClick>();
        
    }
    internal override void DoAction(CubeTrigger Cube)
    {
        containerClick.Cubes.Add(Cube);
        containerClick.CubeNumber++;
    }

    internal override void InteractionExit(CubeTrigger Cube)
    {
        Debug.Log("EXIT TRIGGER WORKS");
        containerClick.Cubes.Remove(Cube);
        containerClick.CubeNumber--;
    }
}
