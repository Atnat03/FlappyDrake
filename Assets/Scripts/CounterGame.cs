using UnityEngine;

public class CounterGame : MonoBehaviour
{
    public static CounterGame instance; void Awake() { instance = this; DontDestroyOnLoad(gameObject);}

    public int gamePlayed = 1;
}
