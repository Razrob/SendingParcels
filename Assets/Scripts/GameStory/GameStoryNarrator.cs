using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStoryNarrator : MonoBehaviour
{
    [SerializeField] private StoryMessage[] emails;


    void Start()
    {
        CurrentDate.notifyChange += SendDayEmail;
    }

    private void SendDayEmail()
    {

    }

}
