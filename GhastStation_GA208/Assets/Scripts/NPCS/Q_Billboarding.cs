using UnityEngine;

public class Q_Billboarding : MonoBehaviour
{
    void Update()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");

        transform.LookAt(camera.transform);
    }
}
