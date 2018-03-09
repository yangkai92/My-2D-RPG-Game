﻿using UnityEngine;
using System.Collections;
public class CharacterMovement : MonoBehaviour
{
    // 玩家角色的刚体2D组件引用
    private Rigidbody2D playerRigidBody2D;

    // 玩家角色的动画组件引用
    private Animator playerAnim;

    // 玩家角色的精灵渲染器组件引用
    private SpriteRenderer playerSpriteImage; 

    // 用于记录玩家角色移动的水平、垂直移动变量和速度变量
    private float movePlayerHorizontal;
    private float movePlayerVertical;
    private Vector2 movement;

    // 玩家移动的速度修正
    public float speed = 4.0f;

    // 初始化组件引用
    void Awake()
    {
        // 手动指明要获得的组件类型，加速组件的获得
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerAnim = (Animator)GetComponent(typeof(Animator));
        playerSpriteImage = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
    }

    void Update ()
    {
        // 将输入所得的水平、垂直分量赋值给玩家的速度向量
        movePlayerHorizontal = Input.GetAxis("Horizontal");
        movePlayerVertical = Input.GetAxis("Vertical");
        movement = new Vector2(movePlayerHorizontal,movePlayerVertical);
        playerRigidBody2D.velocity=movement*speed;

        // 角色移动的动画控制
        if (movePlayerVertical != 0)
        {
            playerAnim.SetBool("xMove", false);
            playerSpriteImage.flipX = false;
            if (movePlayerVertical > 0)
            {
                playerAnim.SetInteger("yMove", 1);
            }
            else if (movePlayerVertical < 0)
            {
                playerAnim.SetInteger("yMove", -1);
            }
        }
        else
        {
            playerAnim.SetInteger("yMove", 0);
            if (movePlayerHorizontal > 0)
            {
                playerAnim.SetBool("xMove", true);
                playerSpriteImage.flipX = false;
            }
            else if (movePlayerHorizontal < 0)
            {
                playerAnim.SetBool("xMove", true);
                playerSpriteImage.flipX = true;
            }
            else
            {
                playerAnim.SetBool("xMove", false);
            }
        }
        // 角色停止的动画控制
        if (movePlayerVertical == 0 && movePlayerHorizontal == 0)
        {
            playerAnim.SetBool("moving", false);
        }
        else
        {
            playerAnim.SetBool("moving", true);
        }
    }
}