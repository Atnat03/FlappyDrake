using UnityEngine;

public class Rock : MoveableObjects
{
    [SerializeField] private float speedRotation = 100f;
    
    public void Update()
    {   
        transform.Rotate(0, 0, speedRotation * Time.deltaTime);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            DrakeController.instance.stats.TakeDamage();
            Destroy(gameObject);
        }
    }
}
