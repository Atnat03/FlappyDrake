using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    public static float scaleTime = 1f; 
    public float increment = 0.1f;      
    public float interval = 20f;       
    public float maxScale = 2f;         
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            if (scaleTime < maxScale)
            {
                scaleTime += increment;
                Debug.Log("Nouveau TimeScale : " + scaleTime);
            }
        }
    }
}