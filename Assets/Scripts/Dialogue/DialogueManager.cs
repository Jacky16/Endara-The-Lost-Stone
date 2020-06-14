using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences = new Queue<string>();

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    TextMeshProUGUI continueText;

    [SerializeField]
    RectTransform rectTransform_Dialogue;

    [SerializeField]
    Animator animBoss;

    [SerializeField]
    AudioSource musicGameplay;
    [SerializeField]
    AudioSource musicCinematic;

    public UnityEvent OnStartDialogue;
    public UnityEvent OnEndDialogue;

    //Variables para el boton de continuar
    [SerializeField]
    Image imageButtonSkip;

    [Header("Components Sprite Button")]
    [SerializeField]
    Sprite spriteButtonSkip_PC;
    [SerializeField]
    Sprite spriteButtonSkip_PS4;
    [SerializeField]
    Sprite spriteButtonSkip_XBOX;

    bool isSpanwingChars;
    bool isInDialogue;
    private void Update()
    {
        ChangeSprite();
    }
    private void Start()
    {
        rectTransform_Dialogue.anchoredPosition = new Vector2(0, -400);
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animBoss.SetTrigger("Talk");
        OnStartDialogue.Invoke();
        isInDialogue = true;
        PlayerMovement.canMove = false;
        nameText.text = dialogue.nameCharacter;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void NextSentenceAction(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            DisplayNextSentence();
        }
    }
    public void DisplayNextSentence()
    {
        if (isInDialogue && !isSpanwingChars)
        {
            if (sentences.Count == 0)
            {
                rectTransform_Dialogue.DOAnchorPosY(-400, .5f).OnComplete(() => EndDialogue());
                return;
            }
            else if (sentences.Count == 1)
            {
                continueText.text = "Exit";
            }
            else
            {
                continueText.text = "Continue >>";
            }
            string sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
            animBoss.SetTrigger("Talk");
        }
        
    }
    IEnumerator TypeSentence(string sentence)
    {
        int countLetter = 0;
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            countLetter++;
            dialogueText.text += letter;
            if(sentence.ToCharArray().Length == countLetter)
            {
                isSpanwingChars = false;
                countLetter = 0;
            }
            else
            {
                isSpanwingChars = true;
            }
            yield return null;
        }
    }
    public void ChangeSprite()
    {
        switch (InputManager.controlsState)
        {
            case InputManager.ControlsState.KeyBoard:
                imageButtonSkip.sprite = spriteButtonSkip_PC;
                break;
            case InputManager.ControlsState.PS4:
                imageButtonSkip.sprite = spriteButtonSkip_PS4;
                break;
            case InputManager.ControlsState.Xbox:
                imageButtonSkip.sprite = spriteButtonSkip_XBOX;
                break;
        }
    }

    void EndDialogue()
    {
        musicGameplay.DOFade(.5f, 1);
        musicCinematic.DOFade(0f, 1);
        OnEndDialogue.Invoke();
        isInDialogue = false;
        PlayerMovement.canMove = true;
    }
}
