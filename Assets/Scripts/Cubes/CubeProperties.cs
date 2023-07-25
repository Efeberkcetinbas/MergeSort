using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CubeProperties : MonoBehaviour
{
    public TextMeshPro[] NumberTexts;

    public List<Color> colors=new List<Color>();
    public int Number;


    internal int CubeID;

    internal bool IsMainCube;

    public CubeData cubeData;

    private void Awake() 
    {
        cubeData.CubeId++;
        CubeID=cubeData.CubeId;
    }

    private void Start() 
    {
        //Renk olayini da ayarla
        for (int i = 0; i < NumberTexts.Length; i++)
        {
            NumberTexts[i].SetText((Number).ToString());
        }
        
    }

    
}
