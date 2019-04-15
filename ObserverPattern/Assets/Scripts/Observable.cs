public abstract class Observable<ObjectType, EventType>
{
    internal Observable<ObjectType, EventType> nextObserver;

    public abstract void OnNotify(ObjectType entity, EventType notiEvent);
}