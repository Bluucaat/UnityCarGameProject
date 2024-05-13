using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button superCarButton;
    [SerializeField] private Button sportsCarButton;


    void Start()
    {
        PlayerPrefs.SetInt("carIndex", 0); //default is sportscar
        PlayerPrefs.Save();
        superCarButton.onClick.AddListener(SelectSuperCar);
        sportsCarButton.onClick.AddListener(SelectSportsCar);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectSuperCar()
    {
        PlayerPrefs.SetInt("carIndex", 1); // Store the selected car name
        PlayerPrefs.Save();
        Debug.Log("Super Car selected");
    }

    public void SelectSportsCar()
    {
        //selectedCar = "SportsCar";
        PlayerPrefs.SetInt("carIndex", 0); // Store the selected car name
        PlayerPrefs.Save();
        Debug.Log("Sports Car selected");
    }
}
