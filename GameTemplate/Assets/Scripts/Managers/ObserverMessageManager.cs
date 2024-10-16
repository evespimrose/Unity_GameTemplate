using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverMessageManager : Subject
{
    private static ObserverMessageManager instance;
    private Queue<IEventMessage> messageQueue = new Queue<IEventMessage>();

    public static ObserverMessageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ObserverMessageManager").AddComponent<ObserverMessageManager>();
            }
            return instance;
        }
    }

    // 메시지를 큐에 추가
    public void AddMessage(IEventMessage message)
    {
        messageQueue.Enqueue(message);
    }

    // 메시지를 처리하고 수신자에게 전송
    public void ProcessMessages()
    {
        while (messageQueue.Count > 0)
        {
            IEventMessage message = messageQueue.Dequeue();
            NotifyObservers(message); // 모든 등록된 옵저버에게 메시지 전송
        }
    }

    // Awake 시점에서 모든 객체가 Observer로 등록
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);  // 씬 전환 시 파괴되지 않음
    }
}
