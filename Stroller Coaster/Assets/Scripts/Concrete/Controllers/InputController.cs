﻿using UnityEngine;

public class InputController
{
    public bool FirstMouseClick => Input.GetMouseButtonDown(0);
    public bool MouseClick => Input.GetMouseButton(0);
}

