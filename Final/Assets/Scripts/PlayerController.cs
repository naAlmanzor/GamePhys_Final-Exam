using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horz, vert, pitch, yaw;
    private Vector3 movement, gravity, wishDir;
    public bool isSwitched = false;
    // public float speed = 10f, sens = 5f, sprintMultiplier = 1f;
    private Camera cam;
    public GameStats gameStats;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;

        gravity = Physics.gravity;
    }

    private void Update() {
        Debug.Log(isGrounded());

        Look();

        if(Input.GetKeyUp(KeyCode.Space)) {
            if(isGrounded()) {
                GravSwitch();
            }
        }

        if(Input.GetKey(KeyCode.LeftShift)) {
            gameStats.playerSprintMultiplier = 1.5f;
        } else {gameStats.playerSprintMultiplier = 1f;}

        Gravity();
    }

    private void FixedUpdate() {
        Movement();
    }

    private void Movement() {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * gameStats.playerSpeed * gameStats.playerSprintMultiplier;
        Vector3 fwd = new Vector3(-cam.transform.right.z, 0f, cam.transform.right.x);
        if(isSwitched) {
            wishDir = (-fwd * axis.x + cam.transform.right * axis.y + Vector3.up * rb.velocity.y);
        } else {
            wishDir = (fwd * axis.x + cam.transform.right * axis.y + Vector3.up * rb.velocity.y);
        }
        
        rb.velocity = wishDir;
    }

    private void Look() {
        pitch -= Input.GetAxisRaw("Mouse Y") * gameStats.cameraSensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        yaw += Input.GetAxisRaw("Mouse X") * gameStats.cameraSensitivity;
        cam.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }

    private void GravSwitch() {
        AudioManager.instance.Play("Gravity");
        isSwitched = !isSwitched;
    }

    private bool isGrounded() {
        if(Physics.Raycast(rb.transform.position, Vector3.down, 1 + 0.001f) || Physics.Raycast(rb.transform.position, Vector3.up, 1 + 0.001f)) {
            return true;
        } else {
            return false;
        }
    }

    private void Gravity() {
        if(isSwitched) {
            rb.velocity = gravity * -1;
            if(rb.rotation.eulerAngles.z < 180) {
                rb.transform.Rotate(0f, 0f, +gameStats.inversionSpeed);
            }
            
        } else if(!isSwitched) {
            rb.velocity = gravity;
            if(rb.rotation.eulerAngles.z > 180) {
                rb.transform.Rotate(0f, 0f, +gameStats.inversionSpeed);
            }
        }
    }
}