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

    // �޽����� ť�� �߰�
    public void AddMessage(IEventMessage message)
    {
        messageQueue.Enqueue(message);
    }

    // �޽����� ó���ϰ� �����ڿ��� ����
    public void ProcessMessages()
    {
        while (messageQueue.Count > 0)
        {
            IEventMessage message = messageQueue.Dequeue();
            NotifyObservers(message); // ��� ��ϵ� ���������� �޽��� ����
        }
    }

    // Awake �������� ��� ��ü�� Observer�� ���
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);  // �� ��ȯ �� �ı����� ����
    }
}
