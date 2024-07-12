using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    [SerializeField] protected float _duration;
    [SerializeField] protected bool isUsed;
    public abstract IEnumerator Use();


}
