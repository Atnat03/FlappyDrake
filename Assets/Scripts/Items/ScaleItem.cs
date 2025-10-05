using UnityEngine;

public class ScaleItem : MoveableObjects
{
    [SerializeField] int scoreValue = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            DrakeController.instance.stats.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
