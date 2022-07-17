using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPosition;

    private void FireProjectile() {
        if (GameManager.gameEnded)
            return;

        GameObject projectile = GameObject.Instantiate(projectilePrefab, projectileSpawnPosition.position + new Vector3(0f, 1f), Quaternion.identity);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            FireProjectile();
        }
    }
}