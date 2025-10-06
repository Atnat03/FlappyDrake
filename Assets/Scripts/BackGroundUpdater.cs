using UnityEngine;

public class BackGroundUpdater : MonoBehaviour
{
    [SerializeField] private GameObject prefabBG;   // ton prefab de background
    [SerializeField] private float speed = 2f;      // vitesse de défilement
    [SerializeField] private int poolSize = 2;      // combien de sprites en même temps (2 suffisent)

    private GameObject[] backgrounds;
    private float spriteWidth;
    private Vector3 startPos;

    void Start()
    {
        SpriteRenderer sr = prefabBG.GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;

        backgrounds = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            Vector3 pos = new Vector3(i * spriteWidth, -3, 0);
            backgrounds[i] = Instantiate(prefabBG, pos, Quaternion.identity, transform);

            if (i % 2 != 0)
            {
                backgrounds[i].GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        startPos = backgrounds[0].transform.position;
    }

    void Update()
    {
        foreach (GameObject bg in backgrounds)
        {
            bg.transform.position += Vector3.left * speed * Time.deltaTime;

            if (bg.transform.position.x <= startPos.x - spriteWidth)
            {
                float maxX = GetFurthestRightX();
                bg.transform.position = new Vector3(maxX + spriteWidth, bg.transform.position.y, bg.transform.position.z);

                SpriteRenderer sr = bg.GetComponent<SpriteRenderer>();
                sr.flipX = !sr.flipX;
            }
        }
    }

    private float GetFurthestRightX()
    {
        float maxX = float.MinValue;
        foreach (GameObject bg in backgrounds)
        {
            if (bg.transform.position.x > maxX)
                maxX = bg.transform.position.x;
        }
        return maxX;
    }
}
