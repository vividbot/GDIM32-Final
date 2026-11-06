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
    private Rigidbody ratRB;

    private void Start()
    {
        Locator.Instance.PickUp.GrabbedRat += RatGrabbed;
        ratRB = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        /*
        if (currentState == RatStates.Running)
        {
            GetComponent<SplineAnimate>().enabled = true;
        }
        */
    }

    public void RatGrabbed()
    {
        //Debug.Log("grabbed rat");
        currentState = RatStates.Grabbed; //somehow, the code needs the state to disable the spline animate component. what.
        GetComponent<SplineAnimate>().enabled = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Running;
        }
    }
    public void OnCollisionExit(Collision other)
    {
        /*
        if (other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Grabbed;
        }
        */
    }

}
