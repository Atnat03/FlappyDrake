using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public float speed = 1.5f;

    protected void Start()
    {
        Destroy(gameObject, 10f);
    }

    protected void FixedUpdate()
    {
        transform.position -= new Vector3(speed * TimeScaler.scaleTime, 0, 0) * Time.fixedDeltaTime;
    }
}
