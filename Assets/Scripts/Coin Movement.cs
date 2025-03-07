using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,60*Time.deltaTime);
    }
}
