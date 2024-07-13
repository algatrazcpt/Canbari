using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RadiusSkill : SkillBase
{
    [SerializeField] Light2D _playerLight;

    [SerializeField] float _addingRadius = 10;

    float timer;
    private void Update()
    {
        // Test
        if (!GetComponent<SeeRadiusSkill>().isUsed)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Used();
            }
            timer += Time.deltaTime;
            if (timer > 1)
            {
                TakeRadius(-.01f);
                timer = 0;
            }
        }


    }
    public override IEnumerator Use()
    {
        if (!isUsed)
        {
            isUsed = true;

            TakeRadius(_addingRadius);

            // Wait for the duration of the animation
            yield return new WaitForSeconds(_duration);

            isUsed = false; // Reset isUsed if needed
        }

        yield return null;
    }
    public void TakeRadius(float _addingRadius)
    {
        // Animate pointLightOuterRadius from current value to current value + 1 over 1 second
        if (_playerLight.pointLightOuterRadius > .5f)
        {
            DOTween.To(() => _playerLight.pointLightOuterRadius, x => _playerLight.pointLightOuterRadius = x, _playerLight.pointLightOuterRadius + _addingRadius, _duration);
        }

    }

    public override void Used()
    {
        StartCoroutine(Use());
    }
}
