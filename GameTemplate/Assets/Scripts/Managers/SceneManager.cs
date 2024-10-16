using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneState
{
    void Enter();  // ���� �� ��
    void Update(); // ������ ������Ʈ�� ��
    void Exit();   // ������ ���� ��
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
