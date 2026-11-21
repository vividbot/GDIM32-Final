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
        Locator.Instance.PickUp.GrabbedRat += RatHasBeenGrabbed;
        ratRB = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (currentState == RatStates.Running)
        {
            GetComponent<SplineAnimate>().enabled = true;
        }
        if(currentState == RatStates.Grabbed)
        {
            GetComponent<SplineAnimate>().enabled = false;
        }

    }

    public void RatHasBeenGrabbed()
    {
        if(gameObject.CompareTag("GrabbedRat"))
        {
            currentState = RatStates.Grabbed;

        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground") && gameObject.CompareTag("GrabbedRat"))
        {
            currentState = RatStates.Running;
            gameObject.tag = "Rat";
        }
    }

}
