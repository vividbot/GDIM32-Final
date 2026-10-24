using System.IO.Compression;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 10.0f; 
    private Rigidbody controller;
    [SerializeField] private float mouseSens = 100.0f;
    public Transform playerBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouse pointing logic
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);


        // Handle Player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    

        

        Vector3 move = transform.right * x + transform.forward * z;

        
        controller.transform.Translate(move * moveSpeed * Time.deltaTime);
    }

}
