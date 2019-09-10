using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 	Defines a ManagerController state
/// </summary>
public interface IState {
    
    void Enter();

    bool IsRunning();

    IState Exit();
}