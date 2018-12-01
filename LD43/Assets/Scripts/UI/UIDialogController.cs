using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogController : MonoBehaviour {

    private UIDialogText __uiDialogText;
    public string message {get; set;}

	// Use this for initialization
	void Start () {
        __uiDialogText = GetComponentInChildren<UIDialogText>();
    }
	
	// Update is called once per frame
	void Update () {
    if (!!__uiDialogText)
        __uiDialogText.currentMessage = message;

    }
}
