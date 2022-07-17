using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update() {
        if (GameManager.gameEnded) {
            rotationSpeed = Mathf.Lerp(rotationSpeed, 0f, Time.deltaTime * 1.8f);
        } else {
            rotationSpeed += Time.deltaTime / 1.5f;
        }

        transform.Rotate((Vector3.forward * rotationSpeed) * (Time.deltaTime));
    }
}
