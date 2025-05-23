using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleSwipeDetector : MonoBehaviour
{
    public float swipeThreshold = 200f;
    public float doubleSwipeTime = 0.4f;

    private GameControls controls;
    private float lastSwipeTime = -1f;

    private void Awake()
    {
        controls = new GameControls();
        DontDestroyOnLoad(this.gameObject); // Ensure persistence (extra layer of safety)
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Gameplay.Swipe.performed += OnSwipePerformed;
    }

    private void OnDisable()
    {
        controls.Gameplay.Swipe.performed -= OnSwipePerformed;
        controls.Disable();
    }

    private void OnSwipePerformed(InputAction.CallbackContext ctx)
    {
        Vector2 delta = ctx.ReadValue<Vector2>();

        if (delta.magnitude > swipeThreshold)
        {
            float time = Time.time;

            if (time - lastSwipeTime < doubleSwipeTime)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }

            lastSwipeTime = time;
        }
    }
}