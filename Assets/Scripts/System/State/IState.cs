using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	Defines a Match state
/// </summary>
public interface IState {
    
    void StartRunning();

    bool IsRunning();

    IState Exit();
}