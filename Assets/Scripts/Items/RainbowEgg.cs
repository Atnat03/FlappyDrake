using UnityEngine;

public class RainbowEgg : MoveableObjects
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Drake"))
        {
            Debug.Log("Rainbow Egg catch");
            Destroy(gameObject);
        }
    }
}
