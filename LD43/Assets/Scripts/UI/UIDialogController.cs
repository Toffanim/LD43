using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogController : MonoBehaviour {

    private UIDialogText __uiDialogText;
    private UIResponseText __uiResponseText;

    public string message {get; set;}
    public string response { get; set; }

    // Use this for initialization
    void Start () {
        __uiDialogText = GetComponentInChildren<UIDialogText>();
        __uiResponseText = GetComponentInChildren<UIResponseText>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!!__uiDialogText)
            __uiDialogText.currentMessage = message;
        if (!!__uiResponseText)
            __uiResponseText.currentMessage = response;
    }
}
