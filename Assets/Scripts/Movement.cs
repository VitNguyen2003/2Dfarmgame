using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        //Huong ma nvat se di
        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);

                if (direction.x > 0)
                    transform.localScale = new Vector3(1, 1);
                else if (direction.x < 0)
                    transform.localScale = new Vector3(-1, 1);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
