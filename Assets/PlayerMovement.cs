using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    //creating a public variable should put a slot in the inspector in Unity
    //we can then drag our CharacterController2D into that slot
    //so now "controller" here, references our CharacterController2D
    //kind of like instantiating it I guess
    public CharacterController2D controller;

    public Animator animator;

    public float moveSpeed = 40f;
    //float vertMove = 0f;
    float horizMove = 0f;
    bool jump = false;

    bool dash = false;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    //good for getting input from the player
    void Update(){
        //val between -1 and 1, changes depends on user input
        //basically just gets the direction
        horizMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        //walking is our parameter from the animation trees in unity
        //walking is between 0 and 1 so we use Mathf.abs since horizMove would be negative if moving to the left
        animator.SetFloat("horizontal", Mathf.Abs(horizMove));



        if(Input.GetKeyDown(KeyCode.LeftShift)){
           moveSpeed *= 2;
        }

        if(Input.GetButtonDown("Jump")){
            jump = true;
        }

    }

    //like update, but called a fixed number of times
    //this avoids the frame rate affecting physics and movement negatively
    void FixedUpdate(){

        //Time.fixedDeltaTime is important!
        controller.Move(horizMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
