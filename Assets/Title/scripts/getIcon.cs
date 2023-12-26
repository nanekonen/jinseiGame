using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetIcon : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public Button buttonCircle;
    public Button buttonSquare;
    public Button buttonTriangle;

    public Sprite spriteCircle;
    public Sprite spriteSquare;
    public Sprite spriteTriangle;

    public float changeTransparency = 0.3f;
    private Sprite clickedSprite;
    private Image[] images = new Image[3];
    private Color currentColor;




    // Start is called before the first frame update
    void Start()
    {
        images[0] = buttonCircle.GetComponent<Image>();
        images[1] = buttonSquare.GetComponent<Image>();
        images[2] = buttonTriangle.GetComponent<Image>();
        AddClickListener(buttonCircle, spriteCircle, images[0]);
        AddClickListener(buttonSquare, spriteSquare, images[1]);
        AddClickListener(buttonTriangle, spriteTriangle, images[2]);
    }

    void AddClickListener(Button button, Sprite sprite, Image image)
    {
        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClick(sprite, image));
        }
    }

    void OnButtonClick(Sprite sprite, Image image)
    {
        this.clickedSprite = sprite;

        if (image.color.a <= 1.0f)
        {
            currentColor = image.color;
            currentColor.a = 1f;
            image.color = currentColor;
        }
        for (int i = 0; i < 3; i++)
        {
            if (images[i] != image)
            {
                currentColor = images[i].color;
                currentColor.a = 0.7f;
                images[i].color = currentColor;
            }
        }
    }

    public Sprite getClickedSprite()
    {
        return clickedSprite;
    }
}
