using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homura : MonoBehaviour
{
    AnimationController animationController;
    SpriteRenderer spriteRenderer;

    bool atacking = false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationController = GetComponent<AnimationController>();
    }
    private void Start()
    {
        animationController.PlayThisAnimation("HomuraIdle");
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            atacking = true;
            animationController.PlayThisAnimation("HomuraAtack");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animationController.PlayThisAnimation("HomuraAtacked");
        }
        else if (animationController.currentAnimation != "HomuraAtack" && animationController.currentAnimation != "HomuraAtacking" && animationController.currentAnimation != "HomuraAtacked")
        {
            atacking = false;
        }

        if (atacking == false)
        {
            if (Input.GetKey(KeyCode.F))
            {
                spriteRenderer.flipX = false;
                animationController.PlayThisAnimation("HomuraRunning");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                spriteRenderer.flipX = true;
                animationController.PlayThisAnimation("HomuraRunning");
            }
            else
            {
                animationController.PlayThisAnimation("HomuraIdle");
            }
        }
    }
}
