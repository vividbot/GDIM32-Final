using UnityEngine;
using UnityEngine.Splines;

public enum RatStates
{
    Running,
    Grabbed,
    Thrown,
}
public class RatMovement : MonoBehaviour
{
    //State Machine
    [SerializeField] RatStates currentState;
    [SerializeField] float currentY;
    [SerializeField] bool isGrounded;
    //
    private void Start()
    {
        
        Locator.Instance.PickUp.GrabbedRat += RatGrabbed;
    }

    public void Update()
    {
        //currentY = transform.position.y;
        /*
        if(currentState == RatStates.Running && isGrounded)
        {
            GetComponent<SplineAnimate>().enabled = true;
        }

        if(currentState == RatStates.Grabbed)
        {
            //GetComponent<SplineAnimate>().enabled = false;
        }\
        */
    }

    public void RatGrabbed()
    {
        GetComponent<SplineAnimate>().enabled = false;
        Debug.Log("StateChange");
        currentState = RatStates.Grabbed;
        //isGrounded = false;
    }

    /*
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && currentState != RatStates.Grabbed)
        {
            currentState = RatStates.Running;
            isGrounded = true;
            Debug.Log("is Grounded");
        }
    }
    */

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Running;
            GetComponent<SplineAnimate>().enabled = true;
        }
    }
}
