using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // スピーカーの役割
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSE;

    public AudioClip[] bgmList;
    public enum BGM
    {
        Title,
        Main,
        Clear
    };

    public AudioClip[] seList;
    public enum SE
    {
        KillEnemy,//敵倒した時
        KillBoss,
        Death,
        Shot,
        ShotHit
        
        
    };

    //どこからでも実行できるようにする　＝＞　シングルトン(static)
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//シーンが変わっても破壊しない
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        //PlayBGM(BGM.Title);
    }

    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        audioSourceBGM.clip = bgmList[index]; // 音をセットする
        audioSourceBGM.Play(); // 再生する
    }
    
    public void PlaySE(SE se)
    {
        int index = (int)se;
        AudioClip clip = seList[index];
        audioSourceSE.PlayOneShot(clip); // 一回ならすもの
    }
}