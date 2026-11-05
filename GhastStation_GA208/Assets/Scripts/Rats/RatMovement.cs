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
        if (currentState == RatStates.Running)
        {
            GetComponent<SplineAnimate>().enabled = true;
            //do animator
        }

        if (currentState == RatStates.Thrown)
        {
            //do animator
        }
    }

    public void RatGrabbed()
    {
        if (currentState != RatStates.Running)
        {
            //do animator + ragdoll stuff
            Debug.Log("grabbed rat");
        }
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
        if (other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Grabbed;
        }
    }

}
