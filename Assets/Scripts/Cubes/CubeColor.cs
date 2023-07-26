using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Colors
{
    red,
    green,
    yellow,
    blue,
    pink,
    orange,
    brown,
    darkGreen,
    mixGreenYellow,
    darkRed,

}

public class CubeColor : MonoBehaviour
{
    private CubeProperties cubeProperties;

    private MeshRenderer meshRenderer;

    private Colors _colors;

    public List<Color> CubeColors=new List<Color>();

    private void Start() 
    {
        cubeProperties=GetComponent<CubeProperties>();
        meshRenderer=GetComponent<MeshRenderer>();

        Checking();
    }

    /*private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnMergeTrigger,OnMergeTrigger);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnMergeTrigger,OnMergeTrigger);
    }*/

    public void Checking()
    {
        CheckNumber();
    }

    private void CheckNumber()
    {
        switch(cubeProperties.Number)
        {
            case 2:
                _colors=Colors.red;
                break;
            case 4:
                _colors=Colors.green;
                break;
            case 8:
                _colors=Colors.yellow;
                break;
            case 16:
                _colors=Colors.blue;
                break;
            case 32:
                _colors=Colors.pink;
                break;
            case 64:
                _colors=Colors.orange;
                break;
            case 128:
                _colors=Colors.brown;
                break;
            case 256:
                _colors=Colors.darkGreen;
                break;
            case 512:
                _colors=Colors.mixGreenYellow;
                break;
            case 1024:
                _colors=Colors.darkRed;
                break;
        }

        CheckColor(_colors);
    }

    private void CheckColor(Colors colors)
    {
        switch(colors)
        {
            case Colors.red:
                meshRenderer.material.color=CubeColors[0];
                break;
            case Colors.green:
                meshRenderer.material.color=CubeColors[1];
                break;
            case Colors.yellow:
                meshRenderer.material.color=CubeColors[2];
                break;
            case Colors.blue:
                meshRenderer.material.color=CubeColors[3];
                break;
            case Colors.pink:
                meshRenderer.material.color=CubeColors[4];
                break;
            case Colors.orange:
                meshRenderer.material.color=CubeColors[5];
                break;   
            case Colors.brown:
                meshRenderer.material.color=CubeColors[6];
                break;
            case Colors.darkGreen:
                meshRenderer.material.color=CubeColors[7];
                break;
            case Colors.mixGreenYellow:
                meshRenderer.material.color=CubeColors[8];
                break;
            case Colors.darkRed:
                meshRenderer.material.color=CubeColors[9];
                break; 
        
                
        }

    }
}
