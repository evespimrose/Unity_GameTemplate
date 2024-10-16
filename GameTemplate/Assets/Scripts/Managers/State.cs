using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : ISceneState
{
    public void Enter()
    {
        Debug.Log("Entering Main Menu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // ���� ���� ��ư�� ������ ��
            SceneManager.Instance.SetState(new GamePlayState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Main Menu");
    }
}

public class GamePlayState : ISceneState
{
    private Player player;
    private Monster monster;

    public void Enter()
    {
        Debug.Log("Entering Game Play");

        // Player�� Monster�� ���� ������Ʈ�κ��� ��������
        player = GameObject.FindObjectOfType<Player>();
        monster = GameObject.FindObjectOfType<Monster>();

        if (player != null && monster != null)
        {
            // �÷��̾�� ���Ͱ� ���� ������ ���
            player.RegisterObserver(monster);
            monster.RegisterObserver(player);
        }

        // �÷��̾ �����ϴ� ���� �̺�Ʈ
        player.Attack(monster);
    }

    public void Update()
    {
        // ���� ���� ������Ʈ (�ʿ�� ��ȣ�ۿ� ó�� ����)
        if (monster != null && monster.health <= 0)
        {
            Debug.Log("Monster defeated, transitioning to next state...");
            SceneManager.Instance.SetState(new MainMenuState()); // ����: ���Ͱ� ������ ���� �޴���
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Game Play");

        // ���� ���� �� ������ ����
        if (player != null && monster != null)
        {
            player.UnregisterObserver(monster);
            monster.UnregisterObserver(player);
        }
    }
}
public class PauseState : ISceneState
{
    public void Enter()
    {
        Debug.Log("Entering Pause");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // �Ͻ����� ����
            SceneManager.Instance.SetState(new GamePlayState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Pause");
    }
}