using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
public class VolumeChangerSlider : VolumeChanger
{
    private Slider slider;

    void Awake(){
        slider = GetComponent<Slider>();
        Assert.IsNotNull(slider);
        slider.onValueChanged.AddListener(ChangeVolume);
    }

    void Start()
    {
        float decibelPreference = PlayerPrefs.GetFloat(parameterName, 0.0f);
        mixer?.SetFloat(parameterName, decibelPreference);
        slider.value = DecibelToLinear(decibelPreference);
    }

    public override void ChangeVolume(float volume){
        base.ChangeVolume(volume);
        PlayerPrefs.SetFloat(parameterName, LinearToDecibel(volume));
    }
}
