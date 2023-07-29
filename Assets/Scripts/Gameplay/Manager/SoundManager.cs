using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioSource> soundEffectSources;

    [Header("Audio Clips")]
    [SerializeField] private List<AudioClip> m_soundEffectClips;
    [SerializeField] private List<AudioClip> m_musicClips;

    public override void Awake()
    {
        base.Awake();
    }

    public void PlaySoundEffect(int audioClipIndex)
    {
        // Check if any sound effect sources are available
        foreach (AudioSource source in soundEffectSources)
        {
            if (!source.isPlaying)
            {
                source.clip = m_soundEffectClips[audioClipIndex];
                source.Play();
                break;
            }
        }
    }

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < m_musicClips.Count)
        {
            musicSource.clip = m_musicClips[index];
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
