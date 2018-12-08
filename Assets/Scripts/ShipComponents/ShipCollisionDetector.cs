using UnityEngine;

public class ShipCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IAsteroidColider collider = other.GetComponent<IAsteroidColider>();
        if (collider != null)
        {
            Debug.Log("trigger entere " + collider.Damage() );
            collider.OnCollision();
        }
        
    }
}