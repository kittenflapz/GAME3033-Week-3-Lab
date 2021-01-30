using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    private Vector2 CrosshairStartingPosition;
    private Vector2 CurrentLookDeltas;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.CursorActive)
        {
            AppEvents.Invoke_OnMouseCursorEnable(false);
        }

        CrosshairStartingPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
