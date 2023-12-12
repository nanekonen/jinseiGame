using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class getIcon : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public Button buttonCircle;
    public Button buttonSquare;
    public Button buttonTriangle;

    private Image lastClickedImage;
    private GameObject checkmark;
    private Vector3 originalScale;

    public static Image icon;

    // Start is called before the first frame update
    void Start()
    {
        AddClickListener(buttonCircle, "icon_circle");
        AddClickListener(buttonSquare, "icon_square");
        AddClickListener(buttonTriangle, "icon_triangle");

        // 初期のスケールを記録
        originalScale = buttonCircle.transform.localScale;
    }

    void AddClickListener(Button button, string iconName)
    {
        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClick(button, iconName));
        }
    }

    void OnButtonClick(Button clickedButton, string iconName)
    {
        //// 直前にクリックされたButtonのチェックマークを非表示にする
        //if (lastClickedImage != null)
        //{
        //    HideCheckmark(lastClickedImage);
        //}

        //// クリックされたButtonにチェックマークを表示する
        //ShowCheckmark(clickedButton);

        //// 直前にクリックされたButtonを更新
        //lastClickedImage = clickedButton.image;

        Debug.Log("Button " + iconName + " clicked!");
        icon = clickedButton.image;
        // ここにクリックされたButtonに対する処理を追加する
    }

    //void ShowCheckmark(Button button)
    //{
    //    if (checkmark == null)
    //    {
    //        // チェックマークがまだ作成されていない場合は作成
    //        checkmark = new GameObject("Checkmark");
    //        checkmark.transform.SetParent(button.transform, false);

    //        // チェックマークのイメージコンポーネントを追加
    //        Image checkmarkImage = checkmark.AddComponent<Image>();
    //        checkmarkImage.sprite = Resources.Load<Sprite>("checkmark"); // チェックマークの画像は適切な画像に変更してください
    //        checkmarkImage.rectTransform.sizeDelta = new Vector2(30, 30); // チェックマークのサイズを適切なサイズに変更してください
    //    }

    //    checkmark.transform.position = button.image.transform.position;
    //    checkmark.SetActive(true);
    //}

    //void HideCheckmark(Image image)
    //{
    //    if (checkmark != null)
    //    {
    //        checkmark.SetActive(false);
    //    }
    //}

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    // マウスカーソルがButton上にあるときの処理
    //    // イメージを少し浮かせる
    //    eventData.pointerEnter.transform.localScale = originalScale * 1.1f;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    // マウスカーソルがButton上から離れたときの処理
    //    // イメージのスケールを元に戻す
    //    eventData.pointerEnter.transform.localScale = originalScale;
    //}
}
