using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : Observable<GameObject, string>
{
    public static TutorialManager Instance = new TutorialManager();

    public override void OnNotify(GameObject entity, string notiEvent)
    {
        Debug.Log(entity.name + notiEvent);
    }
}