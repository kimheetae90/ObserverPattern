using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverMonoBehaviour<ObjectType, EventType> : MonoBehaviour
{
    private Observable<ObjectType, EventType> head;

    public void AddObserver(Observable<ObjectType, EventType> newObserver)
    {
        if (head == null)
        {
            head = newObserver;
        }
        else
        {
            newObserver.nextObserver = head;
            head = newObserver;
        }
    }

    public void RemoveObserver(Observable<ObjectType, EventType> removeObserver)
    {
        if (head == null || removeObserver == null)
        {
            return;
        }

        Observable<ObjectType, EventType> current = head;

        if (current == removeObserver)
        {
            head = current.nextObserver;
        }

        while (current.nextObserver != null)
        {
            if (current.nextObserver == removeObserver)
            {
                LinkNextObserver(current);
                break;
            }

            current = current.nextObserver;
        }
    }

    private void LinkNextObserver(Observable<ObjectType, EventType> currentObserver)
    {
        Observable<ObjectType, EventType> nextObserver = null;
        nextObserver = currentObserver.nextObserver;

        Observable<ObjectType, EventType> nextnextObserver = null;
        if (nextObserver != null)
        {
            nextnextObserver = nextObserver.nextObserver;
        }

        currentObserver.nextObserver = nextnextObserver;
    }

    protected void Notify(ObjectType entity, EventType notiEvent)
    {
        Observable<ObjectType, EventType> current = head;
        while (current != null)
        {
            current.OnNotify(entity, notiEvent);
            current = current.nextObserver;
        }
    }
}