using UnityEngine;

public interface IInput {
    bool TakeCover();
    bool Fire();
    Vector2 Aim();
    Vector2 CameraMovement();
    bool CheckResetCamera();
}