using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private GameObject DownButton;
    [SerializeField] private GameObject UpButton;
    private Vector2 StartUpPosition;
    private float Clamp = 55;
    [SerializeField] private Move move;

    private void Update()
    {
# if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            BeganOrDown();
        }
        else
        if (Input.GetMouseButtonUp(0))
        {
            EndOrUp();
        }
        if (Input.GetMouseButton(0))
        {
            MoveOrPressed();
        }
#elif UNITY_ANDROID
        if(Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                BeganOrDown();
            }
            if(touch.phase == TouchPhase.Moved)
            {
                MoveOrPressed();
            }
            if(touch.phase == TouchPhase.Ended)
            {
                EndOrUp();
            }
        }
#endif
    }

    private void BeganOrDown()
    {
        if (UI.IsUI())
            return;
        DownButton.SetActive(true);
        Vector2 v2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        DownButton.transform.position = v2;
        StartUpPosition = v2;
        move.StartMove();
    }

    private void MoveOrPressed()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        x = Mathf.Clamp(x, DownButton.transform.position.x - Clamp, DownButton.transform.position.x + Clamp);
        y = Mathf.Clamp(y, DownButton.transform.position.y - Clamp, DownButton.transform.position.y + Clamp);
        Vector2 v2 = new Vector2(x, y);
        UpButton.transform.position = v2;
        Vector3 direction = UpButton.transform.position - DownButton.transform.position;
        move.Moving(direction);
    }

    private void EndOrUp()
    {
        if (DownButton.activeInHierarchy == false)
            return;
        UpButton.transform.position = StartUpPosition;
        DownButton.SetActive(false);
        move.EndMove();
    }
}
