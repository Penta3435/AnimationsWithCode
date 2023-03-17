using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "Animations/Animation")]
public class AnimationData : ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float framePerSeg;
    public bool isLoop;
    public string nextAnimationName;
}
