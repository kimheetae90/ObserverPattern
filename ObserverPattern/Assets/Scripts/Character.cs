using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ObserverMonoBehaviour<GameObject, string>
{
    // Use this for initialization
    void Start()
    {
        AddObserver(TutorialManager.Instance);
        AddObserver(AchievementManager.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Notify(this.gameObject, "Jump");
        }
    }
}