using UnityEngine;

public class HP_UI : MonoBehaviour
{
    [SerializeField] GameObject[] hearths;

    public void UpdateUI(int value)
    {
        foreach (GameObject item in hearths)
        {
            item.SetActive(false);
        }

        for (int i = 0; i < value; i++)
        {
            hearths[i].SetActive(true);
        }
    }
}
