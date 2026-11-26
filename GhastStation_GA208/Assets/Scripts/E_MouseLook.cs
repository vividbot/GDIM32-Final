
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private float mouseSens = 100.0f;
    public Transform playerBody;
    private float xRotation = 0f;
    float yRotation;
    private float mouseX;
    private float mouseY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Rigidbody playerRB = player.GetComponent<Rigidbody>();

        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //playerBody.Rotate(Vector3.up * mouseX);

        playerRB.MoveRotation(Quaternion.Euler(0, yRotation, 0));
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

}
