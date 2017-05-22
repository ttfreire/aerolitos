using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
    enum GameState  {None, Menu, Running, Paused, GameOver};
    GameState currentState; 
    AstronautController astronautController;
    UIInformationController UIInformationController;
    float rotationInput, movementInput = 0;

    void Awake () {
        astronautController = GameObject.FindObjectOfType<AstronautController>();
        UIInformationController = GameObject.FindObjectOfType<UIInformationController>();
        currentState = GameState.Running;
    }

    void Update()
    {
        UpdateGameState();
    }

    void GetPlayerInput()
    {
        rotationInput = Input.GetAxis("Horizontal");
        movementInput = Input.GetAxis("Thrust");
    }

    void MovePlayer()
    {
        if (playerCanMove())
        {
            UIInformationController.DisplayCurrentOxygen();
            astronautController.Move();
        }
    }

    void RotatePlayer()
    {
        if (IsRotationInputActive())
        {
            astronautController.Rotate(rotationInput);
        }
    }

    bool IsRotationInputActive()
    {
        if (rotationInput == 0)
            return false;
        else
            return true;
    }

    bool playerCanMove()
    {
        return movementInput > 0 && astronautController.IsDead() == false;
    }

    void EnterGameState(GameState newState)
    {
        ExitGameState();
        currentState = newState;
        switch (currentState)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Running:
                break;
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.GameOver:
                UIInformationController.DisplayGameOver();
                break;
        }
    }

    void UpdateGameState()
    {
        switch (currentState)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Running:
                GetPlayerInput();
                RotatePlayer();
                MovePlayer();
                if (astronautController.IsDead())
                    EnterGameState(GameState.GameOver);
                if (IsPauseButtonPressed())
                    EnterGameState(GameState.Paused);
                break;
            case GameState.Paused:
                if (IsPauseButtonPressed())
                    EnterGameState(GameState.Running);
                break;
            case GameState.GameOver:
                if (Input.GetKey(KeyCode.R))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }

    private static bool IsPauseButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.P);
    }

    void ExitGameState()
    {
        switch (currentState)
        {
            case GameState.None:
                break;
            case GameState.Menu:
                break;
            case GameState.Running:
                break;
            case GameState.Paused:
                ContinueGame();
                break;
            case GameState.GameOver:
                break;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
