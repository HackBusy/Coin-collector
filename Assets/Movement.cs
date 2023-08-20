using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private bool jump=false;
    private bool run=false;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;

    [SerializeField] private float speed;
    [SerializeField] private Vector2 Sensitivity;
    [SerializeField] private float Jumpforce;
    [SerializeField] private collection collectScript;
    // Start is called before the first frame update
    void Start()
    {
        collectScript= FindObjectOfType<collection>();
        Cursor.visible =false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            if(PlayerBody.velocity.y<=0.1&&PlayerBody.velocity.y>=-0.1){
                jump=true;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            run=true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            run=false;
        }
    }
    
    void FixedUpdate()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
        
    }

    void MovePlayer(){
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput)*speed;
        if(run){
            MoveVector=MoveVector*((int)(1+0.2*collectScript.score));
        }
        PlayerBody.velocity = new Vector3(MoveVector.x,PlayerBody.velocity.y,MoveVector.z);

        if(jump){
            PlayerBody.AddForce(Vector3.up*Jumpforce, ForceMode.Impulse);
            jump=false;
        }
    }

    void MovePlayerCamera(){
        xRot -= PlayerMouseInput.y * Sensitivity.y;
        if(xRot>20){
            xRot=20;
        }else if (xRot<-20){
            xRot=-20;
        }
        transform.Rotate(0f,PlayerMouseInput.x*Sensitivity.x,0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot,0f,0f); 
    }
}
