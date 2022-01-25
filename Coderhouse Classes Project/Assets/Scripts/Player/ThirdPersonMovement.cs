using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] float speedMovement = 6f;
    [SerializeField] float speedIncreaseOnSprint = 20f;
    [SerializeField] float turnSmoothTime = 0.04f;
    [SerializeField] Transform cam; 
    float turnSmoothVelocity;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                                                 ref turnSmoothVelocity, turnSmoothTime);
                                                 
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * realSpeedMovement() * Time.deltaTime);
        }

    }

    private bool userIsSprinting(){
        return Input.GetKey(KeyCode.LeftShift);
    }

    private float realSpeedMovement(){
        float speedSmoothTime = Mathf.SmoothStep(speedMovement, speedIncreaseOnSprint, 0.04f);
        return userIsSprinting() ? speedMovement + speedSmoothTime : speedMovement;
    }
}
