using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDialogues : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private Collider2D blueCollider;

    private void Start()
    {
        if (blueCollider != null) 
            Physics2D.IgnoreCollision(playerCollider, blueCollider, true);
    }

    public void Chase1()
    {
        Physics2D.IgnoreCollision(playerCollider, blueCollider, false);
        TimelineManager.Manager.Pause();
        DialogueManager.Manager.LoadDialogue(DialogueManager.Dialogues.CHASE_KEY, true, () => {TutorialManager.Manager.ShowTutorial();});
    }

    public void Chase2()
    {
        TimelineManager.Manager.Pause();
        DialogueManager.Manager.LoadDialogue(DialogueManager.Dialogues.DAMN_IT, true);
    }

    public void TakeOrb()
    {
        DialogueManager.Manager.LoadDialogue(DialogueManager.Dialogues.TAKE_ORB, true, () => {TutorialManager.Manager.ShowTutorial();});
    }

    public void EndTutorial()
    {
        DialogueManager.Manager.LoadDialogue(DialogueManager.Dialogues.ONE_DOWN, true,
            () => { SceneManager.LoadScene("Game");});
    }
}