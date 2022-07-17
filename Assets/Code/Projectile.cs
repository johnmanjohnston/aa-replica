using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private bool hasCollided;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;        
    }

    private void FixedUpdate() {
        if (!hasCollided) {
            rb.AddForce((Vector3.up * speed) * (Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("board")) {
            // print("Projectile collided with board");
            hasCollided = true;

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.transform.parent = collision.transform;

            GameManager.IncrementScore();
        } else {
            if (hasCollided)
                return;

            print("Collided with another projectile!");

            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 0.30980f, 0.12157f);

            GameManager.EndGame();
            StartCoroutine(GameManager.RestartScene());
        }
    }    
}