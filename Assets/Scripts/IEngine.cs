using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEngine
{
    void initEngine();
   void UpdateEngine(Rigidbody rb,DroneControlsListener input);
    void UpdateEngine(Rigidbody rb, int value);
}
