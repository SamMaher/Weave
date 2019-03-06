using System;
using System.Collections.Generic;

/// <summary>
/// 	Defines a Match state
/// </summary>
public interface IState {
    void Enter();

    bool Run();

    IState Exit();
}