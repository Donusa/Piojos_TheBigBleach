using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private short maxJumps = 1;

    private short jumpsLeft;
    private Vector3 jump;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        jumpsLeft = maxJumps;
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft>0)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        jumpsLeft--;
    }
}
