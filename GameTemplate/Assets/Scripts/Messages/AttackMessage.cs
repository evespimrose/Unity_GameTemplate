using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMessage : IEventMessage
{
    public string AttackerName { get; private set; }
    public string TargetName { get; private set; }
    public int Damage { get; private set; }

    public AttackMessage(string attackerName, string targetName, int damage)
    {
        AttackerName = attackerName;
        TargetName = targetName;
        Damage = damage;
    }

    public string GetMessage()
    {
        return $"{AttackerName} attacks {TargetName} for {Damage} damage!";
    }
}
