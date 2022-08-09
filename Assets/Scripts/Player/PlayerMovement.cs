using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //REFERENCES
    private GroundCheck groundCheck;
    private CheckSlope checkSlope;

    //VARIABLES (V)
    [SerializeField] private float acceleration; //V_acceleration movement
    [SerializeField] private float speedMoveSlope;
    [SerializeField] private float maxSpeed; //V_max speed of player movement
    [SerializeField] private float jumpForce;
    private bool canJump = false;
    private bool isJumping = false;

   
    
    //LIFE_CORE
    void Start(){
        groundCheck = GameObject.FindObjectOfType<GroundCheck>();
        checkSlope = GameObject.FindObjectOfType<CheckSlope>();
    }
    void Update()
    {
        Movement();
        
    }

    //METHOD (M)
    private void Movement(){
        if(!checkSlope._isSlope)
        {
            Vector2 velocity = InputManager.InstanceInputManager._player.velocity;
            velocity += InputManager.InstanceInputManager._moveInput * acceleration * Time.fixedDeltaTime;
            InputManager.InstanceInputManager._moveInput = Vector2.zero;
            velocity.x = Mathf.Clamp(velocity.x,-maxSpeed, maxSpeed);
            InputManager.InstanceInputManager._player.velocity = velocity;
        }
        if(checkSlope._isSlope){
            InputManager.InstanceInputManager._player.velocity = new Vector2(-InputManager.InstanceInputManager._moveHorizontal*checkSlope._perPendNormal.x*speedMoveSlope , -InputManager.InstanceInputManager._moveHorizontal*checkSlope._perPendNormal.y*speedMoveSlope);
        }
        Jump();
    }
    private void Jump(){
        if((InputManager.InstanceInputManager._jumpInput)){
            Vector2 newForce = new Vector2(0,jumpForce);
            InputManager.InstanceInputManager._player.velocity =  Vector2.up * jumpForce;
            InputManager.InstanceInputManager._jumpInput = false;
            isJumping = true;

        }else{
            isJumping = false;
        }
    }
}
