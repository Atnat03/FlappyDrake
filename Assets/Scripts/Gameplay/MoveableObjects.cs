using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public float speed = 1.5f;

    void Start()
    {
        Destroy(gameObject, 6f);
    }

    protected void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
    }
}
