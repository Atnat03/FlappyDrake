using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject ui;

    private void Start()
    {
        ClosePanel();
    }

    public void OpenPanel() {ui.SetActive(true); Time.timeScale = 0f;}
    public void ClosePanel() {ui.SetActive(false); Time.timeScale = 1f;}
    
    public void Quitter()
    {
        SceneManager.LoadScene("Menu");
    }
}
