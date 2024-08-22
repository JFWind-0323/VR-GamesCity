using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))] 

public class SoundManager : MonoSingle<SoundManager>
{
    AudioSource audio_source;
    Dictionary<string, AudioClip> audio_dic;
    void Awake()
    {
        audio_source = GetComponent<AudioSource>();
        audio_dic = new Dictionary<string, AudioClip>();
    }

    AudioClip LoadAudioClip(string path)
    {
        return Resources.Load<AudioClip>(path);
    }

    AudioClip GetAudioClip(string path)
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
        Debug.Log(path);
        audio_source.PlayOneShot(GetAudioClip(path), volume);
    }
}
