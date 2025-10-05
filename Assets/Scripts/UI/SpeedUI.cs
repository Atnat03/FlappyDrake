using UnityEngine;
using UnityEngine.UI;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] Image[] speedUI;
    [SerializeField] Sprite noGearSprite;
    [SerializeField] Sprite gearsSprite;

    public void UpdateUI(int value)
    {
        foreach (Image item in speedUI)
        {
            item.sprite = noGearSprite;
        }

        for (int i = 0; i < value; i++)
        {
            speedUI[i].sprite = gearsSprite;
        }
    }
}
