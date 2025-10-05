using UnityEngine;

public class HealthEgg : MoveableObjects
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            DrakeController.instance.stats.AddHealth();
            Destroy(gameObject);
        }
    }
}
