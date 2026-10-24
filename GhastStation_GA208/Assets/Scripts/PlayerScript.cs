using System.IO.Compression;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 10.0f; 
    private Rigidbody controller;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouse pointing logic



        // Handle Player movement
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
    

        

        Vector3 move = transform.right * x + transform.forward * z;

        
        controller.transform.Translate(move * moveSpeed * Time.deltaTime);
    }

}
