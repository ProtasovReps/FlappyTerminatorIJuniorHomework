using UnityEngine;

public class EnemyTargetPosition : MonoBehaviour
{
    public bool IsBusy {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out _))
            IsBusy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out _))
            IsBusy = false;
    }
}
