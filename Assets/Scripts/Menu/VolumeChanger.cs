using UnityEngine.Audio;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    public AudioMixer mixer;
    public string parameterName;

    public virtual void ChangeVolume(float volume){
        mixer?.SetFloat(parameterName, LinearToDecibel(volume));
    }

    public static float LinearToDecibel(float linear)
    {
        float dB;
        if (linear > 0.0f) dB = 20.0f * Mathf.Log10(linear);
        else dB = -144.0f;
        return dB;
    }
    
    public static float DecibelToLinear(float dB)
    {
        float linear;
        if (dB > -144.0f) linear = Mathf.Pow(10.0f, dB/20.0f);
        else linear = 0.0f;
        return linear;
    }
}
