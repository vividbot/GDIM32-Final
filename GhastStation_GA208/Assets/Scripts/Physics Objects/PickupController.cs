using UnityEngine;

public class PickupController : MonoBehaviour
{

    //pickup settings
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    //physics parameters
    [SerializeField] private float pickUpRange = 0.5f;
    [SerializeField] private float pickUpForce = 100f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(heldObject == null) //if there is nothing in our hand:
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) //Ray shot out from the front of the player camera with a range of the esablished pickUpRange.
                {
                    PickUpObject(hit.transform.gameObject); //finds object found by ray
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
            heldObjectRB.linearDamping = 20; //adds a bit of drag to the object (Set to a lower number for more bouncy and high number for less bouncy)
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation; //freezes the rotation of the object.

            heldObjectRB.transform.parent = holdArea;
            heldObject = pickObject;
        }
    }

    void DropObject()
    {
        heldObjectRB.useGravity = true;
        heldObjectRB.linearDamping = 1; 
        heldObjectRB.constraints = RigidbodyConstraints.None;

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
}
