using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 0)]
public class GameData : ScriptableObject 
{

    public int score;
    public int increaseScore;
    public int RequirementContainerNumber;
    public int SuccessContainerNumber;
    public int LevelNumberIndex=1;

    public bool isGameEnd=false;
    public bool canPlayerTouch=true;

}
