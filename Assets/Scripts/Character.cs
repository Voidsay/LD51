using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private CharacterController contrl;
    public Vector3 velocity;
    public bool grounded;

    [SerializeField] float speed = 1;
    [SerializeField] float jumpHight = 1;
    [SerializeField] float gravityScale = 3;

    // Start is called before the first frame update
    void Start()
    {
        contrl = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = contrl.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = -0.1f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        contrl.Move(transform.rotation * move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y += Mathf.Sqrt(jumpHight * -3.0f * Physics.gravity.y * gravityScale);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        contrl.Move(velocity * Time.deltaTime);
    }
}
