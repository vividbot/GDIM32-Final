using UnityEngine;
public enum RatStates
{
    Running,
    Grabbed,
    Thrown,
}
public class RatMovement : MonoBehaviour
{
    Rigidbody rb;

    RatStates currentState;

    float ratSpeed = 4f;
    //float ratDirection;
    //float directionChangeRate = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(currentState == RatStates.Running)
        {
            //move rat
            //timer that counts down. When it hits 0, the rat will change direction
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Running;
        }
    }
}
