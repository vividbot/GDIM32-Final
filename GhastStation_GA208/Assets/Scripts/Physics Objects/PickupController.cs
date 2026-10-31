using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Events

    public delegate void EmptyDelagate();
    public event EmptyDelagate GrabbedRat;

    // layer mask

    public LayerMask IgnoreMe;

    [Header("Pick Up Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickUpRange = 0.5f;
    [SerializeField] private float pickUpForce = 100f;
    [SerializeField] private float pickUpStiffness = 20f; //higher the number, less bounciness. Lower the number, more bounciness. 

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(heldObject == null) //if there is nothing in our hand:
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange, ~IgnoreMe)) // out from the front of the player camera with a range of the esablished pickUpRange.
                {
                    PickUpObject(hit.transform.gameObject); //Triggers PickUpObject method, GameObject found becomes "pickObject" from said method.
                    Debug.Log("Grabbed Object");
                }
            }
            else
            {
                DropObject();
            }
        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjectRB.AddForce(moveDirection * pickUpForce);
        }
    }

    void PickUpObject(GameObject pickObject)
    {
        if(pickObject.GetComponent<Rigidbody>())
        {
            heldObjectRB = pickObject.GetComponent<Rigidbody>(); //grabs held objects RB
            heldObjectRB.useGravity = false; //prevents held object from falling
            heldObjectRB.linearDamping = pickUpStiffness; //adds a bit of drag to the object 
            //heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation; //freezes the rotation of the object.

            heldObjectRB.transform.parent = holdArea;
            heldObject = pickObject;
        }
    }

    void DropObject()
    {
        //This basically undoes everything PickUpObject does. 
        //I'd like to add some force to throw the object a bit, especially in regards to the rats, but that might make some puzzles a bit harder...
        heldObjectRB.useGravity = true;
        heldObjectRB.linearDamping = 1; 
        //heldObjectRB.constraints = RigidbodyConstraints.None;

        heldObjectRB.transform.parent = null;
        heldObject = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 startingPOint = transform.position;
        Vector3 direction = transform.forward * pickUpRange;

        Gizmos.DrawRay(startingPOint, direction);
    }

    //https://www.youtube.com/watch?v=6bFCQqabfzo Utilized this tutorial, though I edited it every so slightly in terms of organization and some variables, also added the gizmo.
    //gone thru and added comments explaining what the code does
}
