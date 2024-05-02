using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Interactable : MonoBehaviour {

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject continueButton;

    void Start() {
        dialogueText.text = "";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T) && playerIsClose) {
            if (dialoguePanel.activeInHierarchy) {
                ZeroText();
            }
            else {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index]) {
            continueButton.SetActive(true);
        }
    }

    public void ZeroText() {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing() {
        foreach (char letter in dialogue[index]) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine() {

        continueButton.SetActive(false);

        if (index < dialogue.Length - 1) {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else {
            ZeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = false;
            ZeroText();
        }
    }
}