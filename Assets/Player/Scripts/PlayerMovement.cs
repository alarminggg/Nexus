using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Transform playerContainer, cameraContainer;

    public float speed = 6.0f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    public float mouseSensitivity = 2f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60f;

    Vector3 moveDirection = Vector3.zero;
    float rotateX, rotateY;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        SetCurrentCamera();
    }

    // Update is called once per frame
    void Update()
    {
        Locomotion();
        RotateAndLook();
    }

    void SetCurrentCamera()
    {
        playerContainer = gameObject.transform.Find("Container");
        cameraContainer = playerContainer.transform.Find("CameraContainer3P");
    }

    void Locomotion()
    {
        if (characterController.isGrounded)//When grounded, set the y-axis to zero(to ignore it)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void RotateAndLook()
    {
        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, rotateX, 0f);
        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);

        cameraContainer.transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);
    }
}
