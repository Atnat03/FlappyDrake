using UnityEngine;

public class DrakeController : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float ySpeed;

    DrakeInput drakeInput;

    void Awake()
    {
        drakeInput = GetComponent<DrakeInput>();

        drakeInput.OnPressLeft += OnRise;
        drakeInput.OnPressRight += OnFall;
        drakeInput.OnRelease += OnRelease;
    }

    void OnDisable()
    {        
        drakeInput.OnPressLeft -= OnRise;
        drakeInput.OnPressRight -= OnFall;
        drakeInput.OnRelease -= OnRelease;
    }

    void FixedUpdate()
    {
        Vector3 newPos = transform.position + new Vector3(0, ySpeed, 0) * Time.fixedDeltaTime;

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(newPos);

        viewportPos.y = Mathf.Clamp(viewportPos.y, 0.2f, 0.9f);

        transform.position = Camera.main.ViewportToWorldPoint(viewportPos);
    }

    void OnFall()
    {
        ySpeed = -speed;
    }

    void OnRise()
    {
        ySpeed = speed;
    }

    void OnRelease()
    {
        ySpeed = 0;
    }
}
