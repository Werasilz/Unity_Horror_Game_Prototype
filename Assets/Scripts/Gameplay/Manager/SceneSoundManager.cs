using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSoundManager : MonoBehaviour
{
    public void PlaySoundEffect(int audioClipIndex)
    {
        SoundManager.Instance.PlaySoundEffect(audioClipIndex);
    }
}
