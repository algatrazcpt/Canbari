using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] Light2D playerLight;
    [SerializeField] bool isLightOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UseIntensitySkill();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnuseIntensitySkill();
        }
    }

    public void UseIntensitySkill()
    {
        StartCoroutine(IncreaseLightIntensityOverTime(10, 2f)); // 10 birim artýþ, 1 saniye süre
    }
    public void UnuseIntensitySkill()
    {
        StartCoroutine(IncreaseLightIntensityOverTime(1, 2f)); // 10 birim artýþ, 1 saniye süre
    }

    private IEnumerator IncreaseLightIntensityOverTime(float targetIntensity, float duration)
    {
        float startIntensity = playerLight.pointLightOuterRadius;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            playerLight.pointLightOuterRadius = Mathf.Lerp(startIntensity, targetIntensity, timeElapsed / duration);
            yield return null;
        }

        playerLight.pointLightOuterRadius = targetIntensity; // Ensure it reaches the target intensity at the end
    }
}
