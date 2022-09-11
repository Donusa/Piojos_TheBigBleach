using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = .3f;
    [SerializeField] private float jumpForce;
    [SerializeField] private short jumpsLeft;
    [SerializeField] private short maxJumps = 1;
    [SerializeField] private CharacterController characterController;

    private Vector3 jump;
    private Rigidbody rb;


    public Camera cam;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       // rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        jumpsLeft = maxJumps;
        characterController = GetComponent<CharacterController>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        Movement();

        /*
         * 
         * 
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if(horizontalInput != 0 || verticalInput != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                Quaternion.Euler(0, Camera.main.transform.localEulerAngles.y , 0),
                                rotationSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            Jump();
        }
         */

    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 dir = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) *  new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 dirNorm = dir.normalized;

        if (dirNorm != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(dirNorm, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                   rot, rotationSpeed * Time.deltaTime);
        }


        characterController.Move(dirNorm * speed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        jumpsLeft--;
    }
}