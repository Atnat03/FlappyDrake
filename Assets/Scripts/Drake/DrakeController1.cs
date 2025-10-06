using System;
using UnityEngine;

public enum Gears
{
    VerySlow,
    Slow,
    Medium,
    Fast,
    VeryFast,
    SpeedOfLight
}

public class DrakeController : MonoBehaviour
{
    public static DrakeController instance;    
    [SerializeField] public Gears curGears;
    [SerializeField] float[] gearsValue = {4,6,8,10,12,14};
    float speed = 4f;
    [SerializeField] float ySpeed;

    DrakeInput drakeInput;
    [SerializeField] SpeedUI speedUI;
    public DragonStats stats;

    private void Awake()
    {
        instance = this;

        drakeInput = GetComponent<DrakeInput>();
    }

    void OnEnable()
    {
        drakeInput.OnPressLeft += OnRise;
        drakeInput.OnPressRight += OnFall;
        drakeInput.OnRelease += OnRelease;
    }

    void Start()
    {
        curGears = Gears.VerySlow;
        speedUI.UpdateUI((int)curGears);
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

    float GetCurSpeed()
    {
        return gearsValue[(int)curGears];
    }

    [ContextMenu("Get gear")]
    public void AddGear()
    {
        if (curGears < Gears.SpeedOfLight)
        {
            curGears++;
            speedUI.UpdateUI((int)curGears);
        }
    }

    void OnFall()
    {
        ySpeed = -GetCurSpeed();
    }

    void OnRise()
    {
        ySpeed = GetCurSpeed();
    }

    void OnRelease()
    {
        ySpeed = 0;
    }
}
