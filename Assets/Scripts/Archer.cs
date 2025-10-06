using System.Collections;
using UnityEngine;

public class Archer : MoveableObjects
{
    [SerializeField] GameObject prefabArrow;
    [SerializeField] Transform spawnArrow;
    [SerializeField] float arrowForce = 10f;

    bool hadThrown = false;
    
    void Update()
    {
        if(transform.position.x <= DrakeController.instance.transform.position.x+3.5f && !hadThrown)
        {
            ShootArrow();
            hadThrown = true;
        }
    }

    private void ShootArrow()
    {
        GameObject arrow = Instantiate(prefabArrow, spawnArrow.position, Quaternion.identity);

        Vector2 direction = (DrakeController.instance.transform.position - spawnArrow.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * arrowForce, ForceMode2D.Impulse);

        Destroy(arrow, 4f);
    }
}
