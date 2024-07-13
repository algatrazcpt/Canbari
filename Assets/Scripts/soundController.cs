using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public AudioClip[] clips;

    public AudioSource soruce;

    public static soundController sound;

    void Awake()
    {
        sound=this;
    }

    public void setSound(int a)
    {
        soruce.clip=clips[a];
        soruce.Play();
    }

}
