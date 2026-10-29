using UnityEngine;
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

    [Header("Rat Game Objects")]
    [SerializeField] private GameObject ratOnGround;
    [SerializeField] private GameObject ratInAir;

    //[Header("Rat Movement Variables")]
    //float ratSpeed = 4f;

    private void Start()
    {
       
    }
    private void Update()
    {
        if(currentState == RatStates.Running)
        {
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime * ratSpeed) ;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            currentState = RatStates.Running;
            Debug.Log("Is Running");
        }
    }
}
