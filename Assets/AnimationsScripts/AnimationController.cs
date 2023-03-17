using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public AnimationData[] Animations;

    public Dictionary<string, AnimationData> animations = new Dictionary<string, AnimationData>();
    public string currentAnimation;
    int currentFrame;
    float timeToChangeFrame;
    float currentTime;

    bool playing = false;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        foreach (AnimationData animation in Animations)
        {
            animations.Add(animation.animationName, animation);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (playing)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeToChangeFrame)
            {
                if (currentFrame < animations[currentAnimation].frames.Length - 1)
                {
                    currentFrame++;
                    spriteRenderer.sprite = animations[currentAnimation].frames[currentFrame];
                }
                else
                {
                    if (animations[currentAnimation].isLoop)
                    {
                        currentFrame = 0;
                        spriteRenderer.sprite = animations[currentAnimation].frames[currentFrame];
                    }
                    else
                    {
                        if(animations[currentAnimation].nextAnimationName != "")
                        {
                            PlayThisAnimation(animations[currentAnimation].nextAnimationName);
                        }
                        else
                        {
                            playing = false;
                        }
                    }
                }
                currentTime = 0;
            }
        }
    }
    public void PlayThisAnimation(string animationName)
    {
        Debug.Log(currentAnimation + "   " + animationName);
        if (currentAnimation != animationName)
        {
            currentAnimation = animationName;
            timeToChangeFrame = 1 / animations[currentAnimation].framePerSeg;
            playing = true;
            currentFrame = 0;
        }
    }
    public void Play()
    {
        playing = true;
    }
    public void Stop()
    {
        playing = false;
    }
    public void Speed(float framePerSeg)
    {
        timeToChangeFrame = 1 / animations[currentAnimation].framePerSeg;
    }
}
