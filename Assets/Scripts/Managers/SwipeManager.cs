using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform ingameContainer;
    public float swipeThreshold = 100f;
    public float transitionSpeed = 10f;
    public float smoothTime = 0.25f;
    private Vector3[] targetPositions;
    private int currentIndex = 0;
    private Vector3 targetPos;
    private bool isLerping = false;

    private Vector2 startPos;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        float width = 10.8f; // đúng theo bạn đang dùng đơn vị thế giới
        targetPositions = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(-width, 0, 0)
        };
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isLerping) return;
        // Optional: có thể thêm drag realtime tại đây nếu cần
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag called!");

        // kiểm tra delta
        float deltaX = eventData.pressPosition.x - eventData.position.x;
        Debug.Log("Delta X = " + deltaX);

        // xử lý chuyển index...
        if (isLerping) return;
        if (Mathf.Abs(deltaX) > swipeThreshold)
        {
            if (deltaX > 0 && currentIndex < targetPositions.Length - 1)
                currentIndex++;
            else if (deltaX < 0 && currentIndex > 0)
                currentIndex--;
        }

        targetPos = targetPositions[currentIndex];
        isLerping = true;
    }

    void Update()
    {
        if (isLerping)
        {
            // Dùng SmoothDamp thay vì Lerp để mượt và chậm dần
            ingameContainer.position = Vector3.SmoothDamp(
            ingameContainer.position,
            targetPos,
            ref velocity,
            smoothTime // thời gian chuyển mượt
            );

            if (Vector3.Distance(ingameContainer.position, targetPos) < 0.01f)
            {
                ingameContainer.position = targetPos;
                isLerping = false;
            }
        }
    }
}
