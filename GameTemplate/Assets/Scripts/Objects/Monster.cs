using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Subject, IObserver
{
    public string monsterName;
    public int health = 100;


    private void Awake()
    {
        ObserverMessageManager.Instance.RegisterObserver(this);
    }
    void Start()
    {
        monsterName = "Goblin";
    }

    public void OnNotify(IEventMessage eventMessage)
    {
        Debug.Log($"Monster received message: {eventMessage.GetMessage()}");

        if (eventMessage is DeathMessage deathMessage)
        {
            // DeathMessage 타입일 때 추가 처리
            Debug.Log($"Monster processes death: {deathMessage.CharacterName}.");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{monsterName} took {damage} damage! Health is now {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{monsterName} has died.");
        // DeathMessage 생성 후 옵저버들에게 알림
        var message = new DeathMessage(monsterName);
        Subject subject = GetComponent<Subject>();
        if (subject != null)
        {
            subject.NotifyObservers(message);
        }
    }
}