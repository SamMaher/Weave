using System;
using System.Collections.Generic;
using UnityEngine;

public interface IState {
    
    void Enter();

    bool IsRunning();

    IState Exit();
}