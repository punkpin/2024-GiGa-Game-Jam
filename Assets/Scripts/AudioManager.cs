using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;//单例模式
    private AudioSource audiosource;//播放组件
    void Start()
    {
        //单例
        Instance= this;
        //获取播放组件
        audiosource= GetComponent<AudioSource>();    
    }

    //播放音效
    public void PlayAudio(string name)
    {
        //通过名称获取音频片段
        AudioClip clip = Resources.Load<AudioClip>(name);
        //播放
        audiosource.PlayOneShot(clip);
    }
    
}
