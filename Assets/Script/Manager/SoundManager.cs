using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBgm;
    [SerializeField] AudioSource audioSourceEffect;
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] effectSounds;

    private void Start()
    {
        if(bgmSounds.Length > 0)
            PlayBgm(bgmSounds[0].name);
    }

    public void PlayBgm(string soundName)
    {
        foreach(var bgm in bgmSounds)
        {
            if(bgm.name == soundName)
            {
                audioSourceBgm.clip = bgm.clip;
                audioSourceBgm.Play();
                return;
            }
        }

        Debug.Log("��� ���� �÷��� ����!!");
    }

    public void PlayEffectSound(string soundName)
    {
        foreach (var bgm in effectSounds)
        {
            if (bgm.name == soundName)
            {
                audioSourceBgm.clip = bgm.clip;
                audioSourceBgm.Play();
                return;
            }
        }

        Debug.Log("ȿ�� ���� �÷��� ����!!");
    }

    public void PauseBgm() { audioSourceBgm.Pause(); }
    public void ResumeBgm() { audioSourceBgm.UnPause(); }
}
