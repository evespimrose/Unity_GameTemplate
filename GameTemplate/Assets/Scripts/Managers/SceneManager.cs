using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneState
{
    void Enter();  // 씬에 들어갈 때
    void Update(); // 씬에서 업데이트될 때
    void Exit();   // 씬에서 나갈 때
}

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }
    private ISceneState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetState(ISceneState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
