using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShacker : MonoBehaviour
{
    public static ScreenShacker instance;

    public CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeSystem(float intensity, float frequency, float duration)
    {
        StartCoroutine(Shake(intensity, frequency, duration));
    }
    // Ekran� sallayan metot
     IEnumerator Shake(float intensity, float frequency, float duration)
    {
        // Shake de�erlerini ayarla
        noise.m_AmplitudeGain = intensity;
        noise.m_FrequencyGain = frequency;

        // Shake s�resi boyunca devam et

        yield return new WaitForSeconds(duration);
        StopShake();

    }

    // Shake'i durduran metot
    private void StopShake()
    {
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }
}
