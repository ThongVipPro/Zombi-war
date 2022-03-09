using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioFileName, AudioClip> audioClips =
        new Dictionary<AudioFileName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioFileName.BGM, Resources.Load<AudioClip>("BGM"));
        audioClips.Add(AudioFileName.PlayerAttack, Resources.Load<AudioClip>("bow"));
        audioClips.Add(AudioFileName.ZombieDeath, Resources.Load<AudioClip>("zombie_death"));
        audioClips.Add(AudioFileName.Coin, Resources.Load<AudioClip>("coin"));
    }

    public static void Play(AudioFileName name)
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(audioClips[name]);
    }

    public static void PlayOnRepeat(AudioFileName name)
    {
        audioSource.loop = true;
        audioSource.PlayOneShot(audioClips[name]);
    }
}
