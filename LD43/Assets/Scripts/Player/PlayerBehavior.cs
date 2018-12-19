using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController2D))]
public class PlayerBehavior : MonoBehaviour {
    [SerializeField] private bool _AllowAirControl = true;

    private CharacterController2D Controller;

    private PlayerInput PInput;
    private bool _IsFacingRight = true;

    private float _HorizontalMovement = 0f;
    private bool _WantsJump = false;
    private bool _WantsAttack = false;

    private bool _Paused = false;

    private void Awake()
    {
        PInput = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        // Escape
        if (Input.GetKey("escape")) Application.Quit(); // TODO (MTN5): Remove from here to a global controller

        if (PInput.Pause.Down)
        {
            if (!_Paused)
            {
                PInput.ReleaseControl(false);
                PInput.Pause.GainControl();
                _Paused = true;
                Time.timeScale = 0;
                //UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("UIMenus", UnityEngine.SceneManagement.LoadSceneMode.Additive);
            }
            else
            {
                Unpause();
            }
        }

        float HMove = PInput.Horizontal.Value;
        if ( HMove < 0 && _IsFacingRight) Flip();
        if ( HMove > 0 && !_IsFacingRight) Flip();
    }

    void FixedUpdate()
    {
        Controller.Move(PInput.Horizontal.Value, PInput.Jump.Down);
    }

    public void Unpause()
    {
        //if the timescale is already > 0, we 
        if (Time.timeScale > 0)
            return;

        StartCoroutine(UnpauseCoroutine());
    }

    protected IEnumerator UnpauseCoroutine()
    {
        Time.timeScale = 1;
        //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("UIMenus");
        PInput.GainControl();
        //we have to wait for a fixed update so the pause button state change, otherwise we can get in case were the update
        //of this script happen BEFORE the input is updated, leading to setting the game in pause once again
        yield return new WaitForFixedUpdate();
        yield return new WaitForEndOfFrame();
        _Paused = false;
    }

    void Flip()
    {
        _IsFacingRight = !_IsFacingRight; // NOTE(MTN5): Dangerous

        Vector3 CurrentLocalScale = transform.localScale; // NOTE(MTN5): Might be better to rotate 180 degrees
        CurrentLocalScale.x *= -1;
        transform.localScale = CurrentLocalScale;
    }
}
