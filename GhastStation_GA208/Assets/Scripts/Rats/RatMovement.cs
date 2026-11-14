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

    /*
    [Header("Rat Game Objects")] 
    [SerializeField] private GameObject ratOnGround;
    [SerializeField] private GameObject ratInAir;

    Saving this just in case I reapproach the double GameObject solution.

    finishing this on Wednesday!!! 
    */

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
        }
    }

    public void RatGrabbed()
    {
        Debug.Log("grabbed rat");
        currentState = RatStates.Grabbed;
        GetComponent<SplineAnimate>().enabled = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Running;
        }
    }

}
