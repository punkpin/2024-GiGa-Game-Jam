using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float jumpUpSpeed = 5f;
    [SerializeField] private float jumpForwardSpeed = 5f;
    [SerializeField] private float upSpeed = 10f;
    [SerializeField] private float fowardSpeed = 10f;
    [SerializeField] private float backwardSpeed = 10f;
    [SerializeField] private float downSpeed = 10f;
    [SerializeField] private float airMovementCDTime = 1f;
    private bool inAirMovementCD;
    private float airMovementCDTimer;
    private Rigidbody2D rb;
    private bool onGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inAirMovementCD = false;
        airMovementCDTimer = airMovementCDTime;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround){
            if(Keyboard.current.spaceKey.wasPressedThisFrame){
            //Debug.Log("Space pressed");
            rb.velocity = Vector2.up * jumpUpSpeed + Vector2.right * jumpForwardSpeed;
        }
        }else{
            if(inAirMovementCD){
                Debug.Log(airMovementCDTimer);
                airMovementCDTimer -= Time.deltaTime;
                if(airMovementCDTimer <= 0){
                    inAirMovementCD = false;
                }
            }else{
                if(Keyboard.current.wKey.wasPressedThisFrame){
                    airMovementCDTimer = airMovementCDTime;
                    //Debug.Log("Move in air");
                    rb.velocity = Vector2.up * upSpeed;
                    inAirMovementCD = true;
                    //Debug.Log("In CD");
                }
                if(Keyboard.current.aKey.wasPressedThisFrame){
                    airMovementCDTimer = airMovementCDTime;
                    //Debug.Log("Move in air");
                    rb.velocity = Vector2.left * backwardSpeed;
                    inAirMovementCD = true;
                    //Debug.Log("In CD");
                }
                if(Keyboard.current.sKey.wasPressedThisFrame){
                    airMovementCDTimer = airMovementCDTime;
                    //Debug.Log("Move in air");
                    rb.velocity = Vector2.down * downSpeed;
                    inAirMovementCD = true;
                    //Debug.Log("In CD");
                }
                if(Keyboard.current.dKey.wasPressedThisFrame){
                    airMovementCDTimer = airMovementCDTime;
                    //Debug.Log("Move in air");
                    rb.velocity = Vector2.right * fowardSpeed;
                    inAirMovementCD = true;
                    //Debug.Log("In CD");
                }
            }
        }        
    }

/*
    public void airMove(){
        if(!onGround){
            airMovementCDTimer = airMovementCDTime;
            Debug.Log("Move in air");
            inAirMovementCD = true;
        }else{
            Debug.Log("In CD");
        }
    }
    */

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")){
            Debug.Log("On ground");
            onGround = true;
            inAirMovementCD = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")){
            Debug.Log("In air");
            onGround = false;
            inAirMovementCD = false;
        }
    }
}
