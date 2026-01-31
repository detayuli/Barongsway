using UnityEngine;

public class CreditRolling : MonoBehaviour
{
  public float scrollSpeed = 50f;

  public RectTransform rectTransform;

  void Start()
  {
    rectTransform = GetComponent<RectTransform>();
  }

  void Update()
  {
    rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
  }
}
