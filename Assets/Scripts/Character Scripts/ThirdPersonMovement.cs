using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public Animator anim;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float gravityForce = -500f;
    private bool playerMove = false;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 gravityvec = new Vector3(0f, gravityForce, 0f);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            playerMove = true;
        }

        if(direction.magnitude <= 0.1f)
        {
            playerMove = false;
        }


        if (playerMove == true)
        {
            anim.SetFloat("Vertical", 1f);
        }
        if(playerMove == false)
        {
            anim.SetFloat("Vertical", 0f);
        }

        #region Gravity
        if(controller.isGrounded && direction.y < 0)
        {
            direction.y = 0f;
        }
        direction.y += gravityForce * Time.deltaTime;
        controller.Move(gravityvec * Time.deltaTime);

        #endregion

    }
}
