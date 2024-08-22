using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource audio_source;
    Dictionary<string, AudioClip> audio_dic;
    void Awake()
    {
        instance = this;
        audio_source = GetComponent<AudioSource>();
        audio_dic = new Dictionary<string, AudioClip>();
        
    }

    public AudioClip LoadAudioClip(string path)
    {
        return (AudioClip)Resources.Load(path);
    }

    private AudioClip GetAudioClip(string path)
    {
        if (!audio_dic.ContainsKey(path))
        {
            audio_dic[path] = LoadAudioClip(path);
        }
        return audio_dic[path];
    }

    public void PlayBGM(string name, float volume = 0.5f)
    {
        audio_source.Stop();
        audio_source.clip = GetAudioClip(name);
        audio_source.volume = volume;
        audio_source.Play();
    }

    public void StopBGM()
    {
        audio_source.Stop();
    }

    public void PlaySoundEffect(string path, float volume = 0.5f)
    {
        audio_source.PlayOneShot(GetAudioClip(path),volume);
        
        
    }
}
