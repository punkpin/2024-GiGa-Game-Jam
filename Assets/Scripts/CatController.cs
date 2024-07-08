using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 2f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float accelerateSpeed = 2f;
    [SerializeField] private float decelerateSpeed = 2f;
    [SerializeField] private float railSpeed = 2f;
    [SerializeField] private float stunDuration = 1f;//眩晕时间为1s
    private float stunStartTime = 0f;//记录眩晕开始的时间
    private Rigidbody2D rb;
    private bool onGround;
    private bool onRail; 
    private bool isbacking = false;
    //动画组件
    private Animator anim;
    //bool动作切换判断
    bool isJump;
    bool isFall;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        onGround = true;
        onRail = false;
        isbacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //切换动画
        SwitchAnimation();
        SwitchAnimations();
        if(!isbacking){
            transform.position += Vector3.right * normalSpeed * Time.deltaTime;
            if(onGround||onRail){
            if(Keyboard.current.spaceKey.wasPressedThisFrame){
            //Debug.Log("Space pressed");
            rb.velocity = new Vector2(rb.velocity.x, (float)Math.Sqrt(2*rb.gravityScale*jumpHeight));
            onGround = false;
            onRail = false;
            //播放跳跃声音
            AudioManager.Instance.PlayAudio("jump");
            }
            if(Keyboard.current.dKey.wasPressedThisFrame){
                anim.SetTrigger("Dash");
                rb.velocity += Vector2.right * accelerateSpeed;
                //播放加速声音
                AudioManager.Instance.PlayAudio("dash");
            }
            if(Keyboard.current.aKey.wasPressedThisFrame){
                if(rb.velocity.x > -normalSpeed/2 ){
                rb.velocity -= Vector2.right * decelerateSpeed;
                }
                //播放减速声音
                AudioManager.Instance.PlayAudio("slow");
            }
            }

            if(onRail){
            transform.position -= Vector3.right * railSpeed * Time.deltaTime;
            }
        }
        //检查眩晕是否结束
        if (stunStartTime > 0f && Time.time - stunStartTime >= stunDuration)
        {
            // 眩晕结束，重置时间戳  
            stunStartTime = 0f;

            // 允许玩家移动
            StartMoving();
        }
    }

     void SwitchAnimation()
    {
        anim.SetBool("isJump", isJump);
        anim.SetBool("isFall", isFall);
    }

    void SwitchAnimations()
    {
        //Walk<->Jump
        if (onGround==false)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }

    void StopMoving()
    {
        normalSpeed=0;
    }

    void StartMoving()
    {
        normalSpeed = 2f;
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")){
            //Debug.Log("On ground");
            onGround = true;
            onRail = false;
            isbacking = false;
        }
        if(other.gameObject.CompareTag("rail")){
            onRail = true;
            isbacking = false;
        }
        if(other.gameObject.CompareTag("ball")){
            isbacking = true;
            AudioManager.Instance.PlayAudio("catMeow");
            rb.velocity = new Vector2(-1.5f,2f);
        }
        if(other.gameObject.CompareTag("roadblock")){
            isbacking = true;
            AudioManager.Instance.PlayAudio("catMeow");
            rb.velocity = new Vector2(-2f,2f);
        }
        if(other.gameObject.CompareTag("banana")){
            isbacking = true;
            AudioManager.Instance.PlayAudio("catMeow");
            rb.velocity = new Vector2(-1.2f,2f);
        }
        if(other.gameObject.CompareTag("car")){
            isbacking = true;
            AudioManager.Instance.PlayAudio("catMeow");
            rb.velocity = new Vector2(-5f,2f);
        }
        //行人
        if (other.gameObject.CompareTag("passenger"))
        {
            isbacking = false;
            anim.SetTrigger("Slow");
            //播放碰撞声音
            AudioManager.Instance.PlayAudio("damage");
            stunStartTime = Time.time;
            StopMoving();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")){
            onGround = false;
            onRail = false;
        }
        if(other.gameObject.CompareTag("rail")){
            onRail = false;
        }
    }
}
