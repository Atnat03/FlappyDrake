using UnityEngine;

public class x2Egg : MoveableObjects
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            DrakeController.instance.stats.Getx2();
            Destroy(gameObject);
        }
    }
}
