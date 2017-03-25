using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    enum GameState  {None, Menu, Running, Paused, GameOver};
    GameState m_currentState; 
    AstronautController m_AstronautController;
    UIInformationController m_UIInformationController;
    // Use this for initialization
    void Awake () {
        m_AstronautController = GameObject.FindObjectOfType<AstronautController>();
        m_UIInformationController = GameObject.FindObjectOfType<UIInformationController>();
        m_currentState = GameState.Running;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameState();
    }

    void FixedUpdate()
    {
        

    }

    void GetPlayerInput()
    {
        //Player Rotation
        m_AstronautController.Rotate(Input.GetAxis("Horizontal"));

        //Player Movement
        if (Input.GetKey(KeyCode.Space) && m_AstronautController.GetCurrentOxygen() > 0)
        {
            m_UIInformationController.DisplayCurrentOxygen();
            m_AstronautController.Move();
        }
    }

    void EnterGameState(GameState newState)
    {
        ExitGameState();
        m_currentState = newState;
        switch (m_currentState)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Running:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                m_UIInformationController.DisplayGameOver();
                break;
        }
    }

    void UpdateGameState()
    {
        switch (m_currentState)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Running:
                GetPlayerInput();
                if (m_AstronautController.IsDead())
                    EnterGameState(GameState.GameOver);
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                if (Input.GetKey(KeyCode.R))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }

    void ExitGameState()
    {
        switch (m_currentState)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Running:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
        }
    }
}
