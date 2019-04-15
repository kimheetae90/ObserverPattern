using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : Observable<GameObject, string>
{
    public static AchievementManager Instance = new AchievementManager();

    public override void OnNotify(GameObject entity, string notiEvent)
    {
        Debug.Log(entity.name + notiEvent);
    }
}