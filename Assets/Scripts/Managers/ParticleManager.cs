using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> pointParticles=new List<ParticleSystem>();


    private void PlayPointParticles()
    {
        for (int i = 0; i < pointParticles.Count; i++)
        {
            pointParticles[i].Play();
        }
    }
}
