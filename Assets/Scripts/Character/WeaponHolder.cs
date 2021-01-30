using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
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

    private void Awake()
    {
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

    public void OnLook(InputValue delta)
    {
        Vector2 independentMousePosition = ViewCamera.ScreenToViewportPoint(PlayerCrossHair.CurrentAimPosition);

        print(independentMousePosition);
    }
}
