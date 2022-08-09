using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{

    //VARIABLES (V)
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform checkGround;
    [SerializeField] private float radiusCheck;
    private bool isGrounded;
    public bool _isGrounded => isGrounded;
   
    void Start()
    {
        checkGround = GameObject.FindObjectOfType<GroundCheck>().GetComponent<Transform>();
        ground = (1<<LayerMask.NameToLayer("Ground"));
    }

    void Update()
    {   
        CheckGroundMethod();
        
    }

    private void CheckGroundMethod()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.transform.position,radiusCheck,ground);       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(checkGround.transform.position,radiusCheck);
    }
}
