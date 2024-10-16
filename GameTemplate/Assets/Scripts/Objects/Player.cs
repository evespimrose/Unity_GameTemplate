using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Subject, IObserver
{
    public string playerName;

    private void Awake()
    {
        ObserverMessageManager.Instance.RegisterObserver(this);
    }

    private void Start()
    {
        playerName = "Hero";
    }

    public void OnNotify(IEventMessage eventMessage)
    {
        Debug.Log($"Player received message: {eventMessage.GetMessage()}");

        if (eventMessage is AttackMessage attackMessage)
        {
            // AttackMessage Ÿ���� �� �߰� ó��
            Debug.Log($"Player processes attack: {attackMessage.AttackerName} -> {attackMessage.TargetName} with {attackMessage.Damage} damage.");
        }
    }

    // ����: �÷��̾ ���͸� ������ ��
    public void Attack(Monster monster)
    {
        int damage = 10;
        Debug.Log($"{playerName} attacks {monster.monsterName}!");
        monster.TakeDamage(damage);

        var message = new AttackMessage(playerName, monster.monsterName, damage);
        ObserverMessageManager.Instance.AddMessage(message);
    }
}

