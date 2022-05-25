using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] Musics;

    void Awake()
    {
        PlayNextSong();
        SetUpSingleton();
    }
    void PlayNextSong()
    {
        AudioClip audio = Musics[Random.Range(0, Musics.Length)];
        GetComponent<AudioSource>().PlayOneShot(audio);
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
}
