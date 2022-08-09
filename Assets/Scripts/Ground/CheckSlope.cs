using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlope : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Vector2 checkPosition;
    [SerializeField] private float sideAngle;
    [SerializeField] private float downAngle;
    [SerializeField] private Vector2 perPendNormal;
    [SerializeField] private float lastDownAngle;

    [SerializeField] private bool isSlope;
    [SerializeField] private bool canMoveOnSlope;
    [SerializeField] private float maxSlopeAngle;
    [SerializeField] private PhysicsMaterial2D friction; //V_friction friction
    [SerializeField] private PhysicsMaterial2D noFriction; //V_friction friction
    
    public bool _isSlope => isSlope;
    public Vector2 _perPendNormal => perPendNormal;
    void Start(){
        
    }
    void Update()
    {
        checkPosition = this.transform.position;
        CheckSlopeVertical();
        CheckSlopeHorizontal();
        MoveOnSlope();
    }
    void CheckSlopeVertical(){
        RaycastHit2D hitVertical = Physics2D.Raycast(checkPosition, Vector2.down, maxDistance, ground);
        if(hitVertical){
            // print("hello yo yo");
            perPendNormal = Vector2.Perpendicular(hitVertical.normal).normalized;
            // Debug.DrawRay(hitVertical.point,hitVertical.normal,Color.blue);
            // Debug.DrawRay(hitVertical.point,perPendNormal,Color.red);
            downAngle = Vector2.Angle(hitVertical.normal,Vector2.up);

            print("down angle: " + downAngle);
            if(downAngle != lastDownAngle){
                isSlope = true;
            }
            lastDownAngle = downAngle;
        }

    }
    void CheckSlopeHorizontal()
    {
        RaycastHit2D hitHorizontalRight = Physics2D.Raycast(checkPosition, Vector2.right, maxDistance, ground);
        RaycastHit2D hitHorizontalLeft  = Physics2D.Raycast(checkPosition, Vector2.left , maxDistance, ground);
        if(hitHorizontalRight)
        {
            Debug.DrawRay(hitHorizontalRight.point,hitHorizontalRight.normal,Color.blue);
            sideAngle = Vector2.Angle(hitHorizontalRight.normal,Vector2.up);
            print("righ" +sideAngle);
            isSlope = true;
            
        }
        else if(hitHorizontalLeft)
        {
            isSlope = true;
            Debug.DrawRay(hitHorizontalLeft.point,hitHorizontalLeft.normal,Color.blue);
            sideAngle = Vector2.Angle(hitHorizontalLeft.normal,Vector2.up);
            print("left" + sideAngle);
            
        }
        else
        {
            sideAngle = 0.0f;
            isSlope = false;
        }
    }
    void MoveOnSlope(){
        if(sideAngle > maxSlopeAngle || downAngle >maxSlopeAngle){
            canMoveOnSlope = false;
        }else{
            canMoveOnSlope = true;
        }

        if(isSlope && canMoveOnSlope && InputManager.InstanceInputManager._moveHorizontal == 0.0f ){
            InputManager.InstanceInputManager._player.sharedMaterial = friction;
        }else{
            InputManager.InstanceInputManager._player.sharedMaterial = noFriction;
        }
    }
  
 
}
