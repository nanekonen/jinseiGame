using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetIcon : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public Button male1;
    public Button male2;
    public Button male3;
    public Button female1;
    public Button female2;
    public Button female3;

    public Sprite male1Icon;
    public Sprite male2Icon;
    public Sprite male3Icon;
    public Sprite female1Icon;
    public Sprite female2Icon;
    public Sprite female3Icon;

    public float changeTransparency = 0.3f;
    private Sprite clickedSprite;
    private Image[] images = new Image[6];
    private Color currentColor;




    // Start is called before the first frame update
    void Start()
    {
        images[0] = male1.GetComponent<Image>();
        images[1] = male2.GetComponent<Image>();
        images[2] = male3.GetComponent<Image>();
        images[3] = female1.GetComponent<Image>();
        images[4] = female2.GetComponent<Image>();
        images[5] = female3.GetComponent<Image>();
        AddClickListener(male1, male1Icon, images[0]);
        AddClickListener(male2, male2Icon, images[1]);
        AddClickListener(male3, male3Icon, images[2]);
        AddClickListener(female1, female1Icon, images[3]);
        AddClickListener(female2, female2Icon, images[4]);
        AddClickListener(female3, female3Icon, images[5]);
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
        for (int i = 0; i < 6; i++)
        {
            if (images[i] != image)
            {
                currentColor = images[i].color;
                currentColor.a = 0.7f;
                images[i].color = currentColor;
            }
        }
    }

    public Sprite getValue()
    {
        return clickedSprite;
    }
}
