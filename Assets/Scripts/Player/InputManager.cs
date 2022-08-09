using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager InstanceInputManager { get; private set;}
    
    //VARIABLES (V)
    [HideInInspector] private Rigidbody2D player; //V_player
    [HideInInspector] private float moveHorizontal; //V_get input x value
    [HideInInspector] private Vector2 moveInput; //V_get input x, y
    private bool jumpInput = false;

    public Rigidbody2D _player => player;
    public float _moveHorizontal => moveHorizontal;
    public bool _jumpInput{
        get{
            return jumpInput;
        }
        set{
            jumpInput = _jumpInput;
        }
    }
    public Vector2 _moveInput{
        get{
            return moveInput;
        }
        set{
            moveInput = _moveInput;
        }
    }

    void Awake(){
        if(InstanceInputManager!= null && InstanceInputManager != this){
            Destroy(this);
        }
        else{
            InstanceInputManager = this;
        }
        
    }
    //LIFE_CORE
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
       
    }
    void Update()
    {
        CheckInput();
        CheckJump();
    }
    //METHOD (M)
    private void CheckInput()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        moveInput = new Vector2(moveHorizontal, 0.0f);
    }
    private void CheckJump(){
        jumpInput = Input.GetKeyDown(KeyCode.B);
    }
}
