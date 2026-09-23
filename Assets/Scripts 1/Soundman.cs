using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;



[System.Serializable]

public class Sound
{

    public string name; // 사운드 이름이자 키값;
    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(0f, 2f)] public float pitch = 1f; // 배속
    public bool loop = false;


}

public class Soundman : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Soundman Instance { get; private set; }

    [Header("사운드목록")]

    [Tooltip("여기에 사운드 추가해라")]
    public Sound[] soundss;

    //딕셔너리
    Dictionary<string, Sound> sounddictionary;

    [Header("볼륨 설정")]
    [Range(0f, 1f)]
    public float mastervolume = 1f;
    [Range(0f, 1f)]
    public float bgmVolume = 1f;
    [Range(0f, 1f)]
    public float effectvolume = 1f;

    AudioSource bgmSource;
    string currentBgm = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //딕셔너리 초기화
        sounddictionary = new Dictionary<string, Sound>();
        //각 사운드 초기화하기
        foreach(Sound s in soundss)
        {
            //dictionary
            GameObject soundobject = new GameObject(("Sound") + s.name);
            soundobject.transform.SetParent(transform);
            //사운드 매니져 밑 에 - > Sound_BGM1 , BGM2....
            s.source = soundobject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            sounddictionary.Add(s.name, s);

        }

        //BGM 전용 오디오 소스

        GameObject bgmobject = new GameObject("BGM");
        bgmobject.transform.SetParent(transform);
        bgmSource = bgmobject.AddComponent<AudioSource>();
        bgmSource.loop = true;

        print($"사운드 매니저의 초기화");
        print($"총 {soundss.Length}개 사운드");


    }

    public void Play(string name, float volumeScale = 1f)
    {
        //딕셔너리에서 사운드 찾기
        if(!sounddictionary.ContainsKey(name))
        {
            Debug.LogError($"사운드 '{name}'을 찾을 수 없다 ㅇㅇ");
            return;
        }

        //키값을 찾았으니 사운드 클래스를 넘겨 주기
        Sound sound = sounddictionary[name];
        //볼륨 적용
        sound.source.volume = mastervolume * effectvolume * sound.volume * volumeScale;
        //플레이 , 재생
        sound.source.Play();
        print($"효과음 재생 : {name}");

    }

    public void PlayBgm(string name, float volumeScale = 1f)
    {
        //딕셔너리에서 사운드 찾기
        if (!sounddictionary.ContainsKey(name))
        {
            Debug.LogError($"사운드 '{name}'을 찾을 수 없다 ㅇㅇ");
            return;
        }
        //이미 같은 BGM인 경우 
        if(currentBgm == name && bgmSource.isPlaying)
        {
            print($"BGM '{name}'이 이미 재생 중");
            return;
        }

        Sound bgm = sounddictionary[name];
        bgmSource.clip = bgm.clip;
        bgmSource.volume = mastervolume * bgmVolume * bgm.volume * volumeScale;
        bgmSource.Play();

        currentBgm = name;

        ////키값을 찾았으니 사운드 클래스를 넘겨 주기
        //Sound sound = sounddictionary[name];
        ////볼륨 적용
        //sound.source.volume = mastervolume * effectvolume * sound.volume * volumeScale;
        ////플레이 , 재생
        //sound.source.Play();
        print($"BGM 재생 : {name}");

    }

    public void SetMastervolume(float volume)
    {
        mastervolume = Mathf.Clamp01(volume);

        if (bgmSource.isPlaying && string.IsNullOrEmpty(currentBgm))
        {
            Sound bgm = sounddictionary[currentBgm];
            bgmSource.volume = mastervolume * bgmVolume * bgm.volume;
        }
    }

    public void SetBGMvolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);

        if(bgmSource.isPlaying && string.IsNullOrEmpty(currentBgm))
        {
            Sound bgm = sounddictionary[currentBgm];
            bgmSource.volume = mastervolume * bgmVolume * bgm.volume;
        }
    }

    public void SetEFFECvolume(float volume)
    {
        effectvolume = Mathf.Clamp01(volume);
    }

    public bool IsPlaying(string name)
    {
        if (!sounddictionary.ContainsKey(name)) return false;

        return sounddictionary[name].source.isPlaying;

    }

    public string GetCurrentBGM()
    {

        return currentBgm;
    }



}
