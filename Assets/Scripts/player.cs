using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    //[SerializeField] private float jumpSpeed = 8.0F;
    //[SerializeField] private float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    [SerializeField] private float sensitivity;
    [SerializeField] private Camera mainCam;
    private CharacterController controller;
    [Header("Misc")]
    public float damage;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        //if (controller.isGrounded && Input.GetButton("Jump")) moveDirection.y = jumpSpeed;

        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;

        if (turner != 0)
        {
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            mainCam.transform.eulerAngles += new Vector3(looker, 0, 0);
        }

        //moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
