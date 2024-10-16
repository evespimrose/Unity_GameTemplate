using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMessage : IEventMessage
{
    public string CharacterName { get; private set; }

    public DeathMessage(string characterName)
    {
        CharacterName = characterName;
    }

    public string GetMessage()
    {
        return $"{CharacterName} has died.";
    }
}
