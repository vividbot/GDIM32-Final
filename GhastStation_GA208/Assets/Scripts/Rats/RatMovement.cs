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
    RatStates currentState;

    private Rigidbody ratRB;

    private SplineAnimate splineAnimator;

    /*
    [Header("Rat Game Objects")] 
    [SerializeField] private GameObject ratOnGround;
    [SerializeField] private GameObject ratInAir;

    Saving this just in case I reapproach the double GameObject solution.
    */

    private void Start()
    {
        Locator.Instance.PickUp.GrabbedRat += RatGrabbed;
        splineAnimator = GetComponent<SplineAnimate>();
        //ratRB = GetComponent<Rigidbody>();
    }

    public void RatGrabbed()
    {
        Debug.Log("grabbed rat");
        currentState = RatStates.Grabbed;
        splineAnimator.enabled = false;
    }

}
