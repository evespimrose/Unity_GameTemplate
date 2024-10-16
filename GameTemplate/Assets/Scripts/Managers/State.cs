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
            // 게임 시작 버튼을 눌렀을 때
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

        // Player와 Monster를 게임 오브젝트로부터 가져오기
        player = GameObject.FindObjectOfType<Player>();
        monster = GameObject.FindObjectOfType<Monster>();

        if (player != null && monster != null)
        {
            // 플레이어와 몬스터가 서로 관찰자 등록
            player.RegisterObserver(monster);
            monster.RegisterObserver(player);
        }

        // 플레이어가 공격하는 예시 이벤트
        player.Attack(monster);
    }

    public void Update()
    {
        // 게임 로직 업데이트 (필요시 상호작용 처리 가능)
        if (monster != null && monster.health <= 0)
        {
            Debug.Log("Monster defeated, transitioning to next state...");
            SceneManager.Instance.SetState(new MainMenuState()); // 예시: 몬스터가 죽으면 메인 메뉴로
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Game Play");

        // 씬을 나갈 때 관찰자 해제
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
            // 일시정지 해제
            SceneManager.Instance.SetState(new GamePlayState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Pause");
    }
}