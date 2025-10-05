using UnityEngine;

public class SpeedEgg : MoveableObjects
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            DrakeController.instance.AddGear();
            Destroy(gameObject);
        }
    }
}
