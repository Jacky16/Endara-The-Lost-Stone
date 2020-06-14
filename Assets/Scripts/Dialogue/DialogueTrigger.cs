using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField]
    RectTransform rectTransform_Dialogue;

    public void TriggerDialogue()
    {
        rectTransform_Dialogue.DOAnchorPosY(0, .5f).OnComplete(() => StartDialogue());
    }
    void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }
}
