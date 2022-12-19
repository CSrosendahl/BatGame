using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    Rigidbody rb;
    public float moveSpeed = -50;
    public Camera batCam;

    public float lookSensitivity = 1; // mouse look sensitivity

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("FlyFast", true);
            rb.constraints = RigidbodyConstraints.None;
            moveSpeed = -100;
            
        } else
        {
            anim.SetBool("FlyFast", false);
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            moveSpeed = -50;

        }
        Debug.Log(anim.GetBool("FlyFast"));

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);

        // Rotation
        Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        Quaternion rotation = transform.rotation;
        Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
        transform.rotation = horiz * rotation * vert;
    }
}
