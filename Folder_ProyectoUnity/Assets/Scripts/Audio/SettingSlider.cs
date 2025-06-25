using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingSlider : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private string key;
    private float volume;

    [Header("Slider")]
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateValue);
    }

    private void Start()
    {
        volume = PlayerPrefs.GetFloat(key, 1f);
        slider.value = Mathf.Clamp01(volume);
        UpdateValue(volume);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    private void UpdateValue(float value)
    {
        volume = Mathf.Clamp(value, 0.0001f, 1f);
        mainMixer.SetFloat(key, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(key, volume);
    }
}