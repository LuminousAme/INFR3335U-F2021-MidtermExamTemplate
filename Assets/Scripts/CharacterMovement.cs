using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    //character movement
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float mouseSensetivity = 5f;
    [SerializeField] private float rotRate = 5f;

    //input
    Vector2 input;

    //rotation
    float rot;
    float cameraRot;
    [SerializeField] private Transform camTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rot = transform.localRotation.eulerAngles.y;
        cameraRot = camTarget.localRotation.eulerAngles.y;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //get input 
        input.y = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");

        //rotate the player
        if(Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            rot += Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0.0f, rot, 0.0f), rotRate * Time.deltaTime);
        }
        //rotate the camera
        else if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            cameraRot += Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
            camTarget.localRotation = Quaternion.Slerp(camTarget.localRotation, Quaternion.Euler(0.0f, cameraRot, 0.0f), rotRate * Time.deltaTime);
        }
    }

    // Fixed update called once per physics step
    private void FixedUpdate()
    {
        //apply the positional movement
        Vector3 moveDir = (transform.forward * input.y + transform.right * input.x);
        rb.velocity = moveDir * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coins")
        {
            Destroy(other.gameObject);
            GameManager.coins += 1;
;       }
    }
}
