using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShuffle : MonoBehaviour
{
    public List<Vector3> positions=new List<Vector3>();

    public List<Transform> cubes=new List<Transform>();


    private void Start() 
    {
        Shuffling();
    }

    private void Shuffling()
    {
        cubes.Shuffle(cubes.Count);
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].localPosition=positions[i];
        }
    }

}
