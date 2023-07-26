using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip GameLoop,BuffMusic;
    public AudioClip MergeSound,GameOverSound,BreakeableSound,FailSound,SelectSound;

    AudioSource musicSource,effectSource;

    private bool hit;

    private void Start() 
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = GameLoop;
        //musicSource.Play();
        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.volume=0.4f;
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.AddHandler(GameEvent.OnMergeTrigger,OnMergeTrigger);
        EventManager.AddHandler(GameEvent.OnBreakWindow,OnBreakWindow);
        EventManager.AddHandler(GameEvent.OnFail,OnFail);
        EventManager.AddHandler(GameEvent.OnSelect,OnSelect);
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.RemoveHandler(GameEvent.OnMergeTrigger,OnMergeTrigger);
        EventManager.RemoveHandler(GameEvent.OnBreakWindow,OnBreakWindow);
        EventManager.RemoveHandler(GameEvent.OnFail,OnFail);
        EventManager.RemoveHandler(GameEvent.OnSelect,OnSelect);
    }

    

    private void OnGameOver()
    {
        effectSource.PlayOneShot(GameOverSound);
    }

    private void OnMergeTrigger()
    {
        effectSource.PlayOneShot(MergeSound);
    }

    private void OnBreakWindow()
    {
        //effectSource.PlayOneShot(BreakeableSound);
    }

    private void OnFail()
    {
        effectSource.PlayOneShot(FailSound);
    }

    private void OnSelect()
    {
        effectSource.PlayOneShot(SelectSound);
    }



}
