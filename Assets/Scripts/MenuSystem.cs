using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public InputField insertName;

    public string nameInserted;

    public UnityEngine.UI.Button startGame;
    public UnityEngine.UI.Button exitGame;

    public Text displayedName;
    public Text displayedBest;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        
        insertName.onEndEdit.AddListener(StoreName);
        startGame.onClick.AddListener(StartButtonPressed);
        exitGame.onClick.AddListener(ExitButtonPressed);

    }

    private void Start()
    {
        displayedName.text = $"Insert your Name";
        displayedBest.text = $"High Score: {MenuManager.Instance.bestPlayer} ({MenuManager.Instance.highScore})";

    }

    public void StoreName(string name)
    {
        displayedName.text = name;
        MenuManager.Instance.playerName = name;
    }

    public void StartButtonPressed()
    {
        MenuManager.Instance.StartGame();
    }
    
    public void ExitButtonPressed()
    {
        MenuManager.Instance.ExitGame();
    }

}
