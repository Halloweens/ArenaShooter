using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    public float movementSpeed = 6f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotateDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            
            rotateDirection = new Vector3(0, Input.GetAxis("Rotation"), 0);
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            transform.eulerAngles += rotateDirection;
            moveDirection *= movementSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
