using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class InstensitySkill : SkillBase
{
    [SerializeField] Light2D _playerLight;
    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;

    [SerializeField] float _maxTargetLightInstensity = 10;
    [SerializeField] float _maxTargetCameraSize = 10;

    float exMaxTargetLightInstensity;
    float exTargetCameraSize;

    private void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(Use());
        }
    }
    public override IEnumerator Use()
    {
        if (!isUsed)
        {
            exMaxTargetLightInstensity = _playerLight.pointLightOuterRadius;
            exTargetCameraSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;

            ApproachLightAndCameraOverTime(_maxTargetLightInstensity, _maxTargetCameraSize, _duration);
            yield return new WaitForSeconds(_duration);
            MoveAwayLightAndCameraOverTime(exMaxTargetLightInstensity, exTargetCameraSize, _duration);
        }
    }

    private void ApproachLightAndCameraOverTime(float targetLightIntensity, float targetCameraSize, float duration)
    {
        isUsed = true;
        // Light intensity tween
        DOTween.To(() => _playerLight.pointLightOuterRadius, x => _playerLight.pointLightOuterRadius = x, targetLightIntensity, duration).OnComplete(() =>
        {
            _playerLight.pointLightOuterRadius = targetLightIntensity;
        });

        // Camera size tween
        DOTween.To(() => _cinemachineVirtualCamera.m_Lens.OrthographicSize, x => _cinemachineVirtualCamera.m_Lens.OrthographicSize = x, targetCameraSize, duration).OnComplete(() =>
        {
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = targetCameraSize;
        });
    }
    private void MoveAwayLightAndCameraOverTime(float targetLightIntensity, float targetCameraSize, float duration)
    {
        // Light intensity tween
        DOTween.To(() => _playerLight.pointLightOuterRadius, x => _playerLight.pointLightOuterRadius = x, targetLightIntensity, duration).OnComplete(() =>
        {
            _playerLight.pointLightOuterRadius = targetLightIntensity;
        });

        // Camera size tween
        DOTween.To(() => _cinemachineVirtualCamera.m_Lens.OrthographicSize, x => _cinemachineVirtualCamera.m_Lens.OrthographicSize = x, targetCameraSize, duration).OnComplete(() =>
        {
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = targetCameraSize;
            isUsed = false;
        });
    }
}
