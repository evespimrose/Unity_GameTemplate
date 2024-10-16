using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Observer 인터페이스
public interface IObserver
{
    void OnNotify(IEventMessage eventMessage);
}

// Subject 인터페이스
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers(IEventMessage eventMessage);
}

public class Subject : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void NotifyObservers(IEventMessage eventMessage)
    {
        foreach (IObserver observer in observers)
        {
            observer.OnNotify(eventMessage);
        }
    }
}