using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public float speed = 3;

    protected void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
    }
}
