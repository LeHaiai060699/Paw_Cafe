using UnityEngine;

public class Customer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject orderBubblePrefab;
    private GameObject currentBubble;

    public void SitAtTable(Transform table)
    {
        transform.position = table.position;
        ShowOrder();
    }

    void ShowOrder()
    {
        currentBubble = Instantiate(orderBubblePrefab, transform);
        currentBubble.transform.localPosition = new Vector3(0, 1.5f, 0);
    }

    public void ReceiveFood()
    {
        if (currentBubble != null)
            Destroy(currentBubble);

        // Add animation or satisfaction reaction here
        Debug.Log("Customer is happy!");
    }
}
