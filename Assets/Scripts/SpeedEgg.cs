using UnityEngine;

public class SpeedEgg : MoveableObjects
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            Debug.Log("Egg catch");
            Destroy(gameObject);
        }
    }
}
