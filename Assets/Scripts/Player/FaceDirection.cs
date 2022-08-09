using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{

    private int faceFlipDirection = 1;

    //LIFE_CORE
    void FixedUpdate()
    {
        CheckFaceFlip();
    }

    //METHOD (M)
    private void CheckFaceFlip(){
        if(InputManager.InstanceInputManager._moveHorizontal == -1 && faceFlipDirection == 1){
            FlipFace();
        }else if(InputManager.InstanceInputManager._moveHorizontal == 1 && faceFlipDirection == -1){
            FlipFace();
        }
    }
    private void FlipFace(){
        this.transform.Rotate(0.0f,180.0f,0.0f);
        faceFlipDirection *= -1;
    }

}