using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    [SerializeField] protected float _duration;
    [SerializeField] public bool isUsed;
    public abstract IEnumerator Use();


}
