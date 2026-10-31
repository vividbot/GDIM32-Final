
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 10.0f; 
    private CharacterController controller;   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle Player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        
        controller.Move(move * moveSpeed * Time.deltaTime);

    }

}
