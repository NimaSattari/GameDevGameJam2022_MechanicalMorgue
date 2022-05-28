using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] Musics;
    [SerializeField] AudioClip win, lose;
    AudioSource source;

    void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        PlayNextSong();
    }

    void PlayNextSong()
    {
        AudioClip audio = Musics[Random.Range(0, Musics.Length)];
        source.clip = audio;
        source.Play();
        Invoke("PlayNextSong", audio.length);
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayWin()
    {
        CancelInvoke();
        source.Stop();
        GetComponent<AudioSource>().PlayOneShot(win);
        Invoke("PlayNextSong", 4f);
    }
    public void PlayLose()
    {
        CancelInvoke();
        source.Stop();
        GetComponent<AudioSource>().PlayOneShot(lose);
        Invoke("PlayNextSong", 4f);
    }
}
