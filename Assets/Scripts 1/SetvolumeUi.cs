using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SetvolumeUi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider effecSlider;

    public TextMeshPro mastertxt;
    public TextMeshPro bgmtxt;
    public TextMeshPro effectxt;

    void Start()
    {
        masterSlider.value = Soundman.Instance.mastervolume;
        bgmSlider.value = Soundman.Instance.bgmVolume;
        effecSlider.value = Soundman.Instance.effectvolume;

        masterSlider.onValueChanged.AddListener(OnMasterChanger);
        bgmSlider.onValueChanged.AddListener(OnBgmChanged);
        effecSlider.onValueChanged.AddListener(OneffectChange);

    }
    void OnMasterChanger(float value)
    {
        Soundman.Instance.SetMastervolume(value);
    }

    void OnBgmChanged(float value)
    {
        Soundman.Instance.SetBGMvolume(value);
    }

    void OneffectChange(float value)
    {
        Soundman.Instance.SetEFFECvolume(value);
    }

    void Updatetxt()
    {
        mastertxt.text = $"Master: {(masterSlider.value * 100): F0}";
        bgmtxt.text = $"Master: {(bgmSlider.value * 100): F0}";
        effectxt.text = $"Master: {(effecSlider.value * 100): F0}";
    }


    // Update is called once per frame

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            // 소리 출력
            Soundman.Instance.Play("BGM1");
        }
    }
}
