using UnityEngine;

public class Arrow : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            DrakeController.instance.stats.TakeDamage();
            Destroy(gameObject);
        }
    }
}
