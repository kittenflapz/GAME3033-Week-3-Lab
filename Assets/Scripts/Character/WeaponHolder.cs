using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : InputMonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    private GameObject WeaponToSpawn;

    [SerializeField]
    private Transform WeaponSocketLocation;

    // Components
    PlayerController PlayerController;
    Crosshair PlayerCrossHair;
    Animator PlayerAnimator;

    // Ref
    Camera ViewCamera;

    private new void Awake()
    {
        base.Awake();
        PlayerController = GetComponent<PlayerController>();
        PlayerAnimator = PlayerController.GetComponent<Animator>();
        if (PlayerController)
        {
            PlayerCrossHair = PlayerController.CrossHair;
        }

        ViewCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
      Instantiate(WeaponToSpawn, WeaponSocketLocation.position, WeaponSocketLocation.rotation, WeaponSocketLocation);
    }

    public void OnLookFix(InputAction.CallbackContext obj)
    {
        Vector3 independentMousePosition = ViewCamera.ScreenToViewportPoint(PlayerCrossHair.CurrentAimPosition);
        print(independentMousePosition);

        PlayerAnimator.SetFloat("AimHorizontal", independentMousePosition.x);
        PlayerAnimator.SetFloat("AimVertical", independentMousePosition.y);
    }

    private new void OnEnable()
    {
        base.OnEnable();
        GameInput.PlayerActionMap.Look.performed += OnLookFix;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        GameInput.PlayerActionMap.Look.performed -= OnLookFix;
    }
}
