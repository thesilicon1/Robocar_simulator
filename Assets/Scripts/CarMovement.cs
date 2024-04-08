using System.Threading.Tasks;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    public enum State { Idle, MovingForward, MovingBackward, TurningLeft, TurningRight }
    public State currentState = State.Idle;
    public float starttime;
    public WheelCollider CWFR_3, CWFL_3;
    public Transform TWFR_3, TWFL_3;

    private void UpdateWheelRotation() {
        TWFR_3.Rotate((CWFR_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TWFL_3.Rotate((CWFL_3.rpm * 3) / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
    }

    private void ApplyTorque(float torqueFront, float torqueBack) {
        CWFR_3.motorTorque = torqueFront;
        CWFL_3.motorTorque = torqueBack;
    }

    public void Movement(float lf, float rf, int timedelta) {
        UpdateWheelRotation();

        if (Input.GetKeyDown(KeyCode.W)) {
            currentState = State.MovingForward;
            starttime = Time.unscaledTime;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            currentState = State.MovingBackward;
            starttime = Time.unscaledTime;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            currentState = State.TurningLeft;
            starttime = Time.unscaledTime;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            currentState = State.TurningRight;
            starttime = Time.unscaledTime;
        }

        switch (currentState) {
            case State.MovingForward:
                if (Time.unscaledTime - starttime <= timedelta / 1.5)
                    ApplyTorque(rf, lf);
                else
                    currentState = State.Idle;
                break;
            case State.MovingBackward:
                if (Time.unscaledTime - starttime <= timedelta / 1.5)
                    ApplyTorque(-rf, -lf);
                else
                    currentState = State.Idle;
                break;
            case State.TurningLeft:
                if (Time.unscaledTime - starttime <= timedelta / 1.1)
                    ApplyTorque(-rf, lf);
                else
                    currentState = State.Idle;
                break;
            case State.TurningRight:
                if (Time.unscaledTime - starttime <= timedelta / 1.1)
                    ApplyTorque(rf, -lf);
                else
                    currentState = State.Idle;
                break;
            default:
                ApplyTorque(0f, 0f);
                break;
        }
    }
}