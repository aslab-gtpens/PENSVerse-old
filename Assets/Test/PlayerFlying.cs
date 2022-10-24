using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlying : MonoBehaviour
{
    [SerializeField] MainInputManager inputManager;
    [SerializeField] CharacterController characterController;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotateSpeed = 100;
    

    private float yAxisRotation;
    private float xAxisRotation;

    private float minimumPivot = -90;
    private float maximumPivot = 90;

    [SerializeField] Transform cameraPivot;
    

    private void Update()
    {
        Look();
        Move();
    }

    private void Move()
    {
        
        Vector3 moveDir = cameraPivot.forward * inputManager.moveAxis.y;
        moveDir += cameraPivot.right * inputManager.moveAxis.x;
        
        characterController.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    private void Look()
    {
        //Get look input from input manager
        Vector2 lookAxis = inputManager.lookAxis * Time.deltaTime;

        
        //rotate player + camera
        xAxisRotation -= lookAxis.y * rotateSpeed;
        yAxisRotation += lookAxis.x * rotateSpeed;

        xAxisRotation = Mathf.Clamp(xAxisRotation, minimumPivot, maximumPivot); // restrict vertical rotation

        Vector3 HorizontalLook = new Vector3(0, yAxisRotation * characterController.transform.up.y, 0);
        Vector3 VerticalLook = new Vector3(xAxisRotation, 0, 0);

        //look
        characterController.transform.localRotation = Quaternion.Euler(HorizontalLook);
        cameraPivot.localRotation = Quaternion.Euler(VerticalLook);
        
    }
}
