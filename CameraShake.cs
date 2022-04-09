using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera myCinemachine;
    public CinemachineBasicMultiChannelPerlin perlin;
    private float shakeTimer = 0;

    private void Awake()
    {
        Instance = this;
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
        perlin = myCinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float timer)
    {

        //CinemachineBasicMultiChannelPerlin perlin = myCinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()
        perlin.m_AmplitudeGain = intensity;

        shakeTimer = timer;
    }
    private void Update()
    {

        shakeTimer -= Time.deltaTime;
        if (shakeTimer <= 0f)
        {
            //CinemachineBasicMultiChannelPerlin perlin = myCinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()
            perlin.m_AmplitudeGain = 0f;
        }
    }
}
