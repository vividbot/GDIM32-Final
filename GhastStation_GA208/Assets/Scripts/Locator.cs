using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public PickupController PickUp { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance == this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject playerObj = GameObject.FindWithTag("Player");
        PickUp = playerObj.GetComponent<PickupController>();
    }
}
