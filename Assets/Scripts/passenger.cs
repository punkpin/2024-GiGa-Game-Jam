using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passenger : MonoBehaviour
{
    // 初始速度  
    public float initialSpeed = 1.8f;
    // 加速后的速度  
    public float acceleratedSpeed = 5.0f;
    // 加速前的随机等待时间范围  
    public float randomWaitTimeMin = 5.0f;
    public float randomWaitTimeMax = 8.0f;
    // 设置敌人开始移动的最小距离  
    public float activationDistance = 0.2f;
    // 玩家的引用，可以通过Unity编辑器直接赋值  
    public Transform player;
    // 用来控制敌人是否应该移动  
    private bool isMoving = false;


    // Rigidbody2D组件引用  
    private Rigidbody2D rb;

    // 用于存储开始加速的时间  
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 初始化时以初始速度移动  
        if (isMoving == true)
        {
            rb.velocity = new Vector2(initialSpeed, 0f);
            startTime = Time.time + Random.Range(randomWaitTimeMin, randomWaitTimeMax);
        }
        
        //transform.position += Vector3.right * initialSpeed * Time.deltaTime;

        // 在5到8秒之间的随机时间后开始加速  

    }

    void Update()
    {
        // 检查玩家是否在激活距离内  
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= activationDistance && !isMoving)
        {
            // 开始移动  
            isMoving = true;
            Debug.Log("敌人开始移动！");
        }

        // 检查是否到了加速的时间
        if (isMoving==true&&Time.time<startTime)
        {
            rb.velocity = new Vector2(initialSpeed, 0f);
        }
        else if (Time.time >= startTime)
        {
            // 加速并改变方向（假设是向右移出屏幕）  
            rb.velocity = new Vector2(acceleratedSpeed, 0f);

            // 检查是否已移出屏幕（这里假设屏幕宽度为Screen.width）  
            if (transform.position.x > Screen.width + 10) // 假设障碍物在屏幕右侧外10个单位处消失  
            {
                Destroy(gameObject); // 销毁障碍物  
            }
        }
    }

}
