
using UnityEngine;

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
        // Handle Player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = transform.InverseTransformDirection(transform.forward) * z;
        Vector3 right = transform.InverseTransformDirection(transform.right) * x;
        // Vector3 move = transform.right * x + transform.forward * z;
        Vector3 move = forward + right;

        
        controller.transform.Translate(move * moveSpeed * Time.deltaTime);
        // Debug.Log(forward + "forward");
        // Debug.Log(right + "right");
        Debug.Log(x + "x");
        Debug.Log(z + "z");
    }

}
