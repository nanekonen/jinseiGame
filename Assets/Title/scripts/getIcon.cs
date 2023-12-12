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

        // �����̃X�P�[�����L�^
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
        //// ���O�ɃN���b�N���ꂽButton�̃`�F�b�N�}�[�N���\���ɂ���
        //if (lastClickedImage != null)
        //{
        //    HideCheckmark(lastClickedImage);
        //}

        //// �N���b�N���ꂽButton�Ƀ`�F�b�N�}�[�N��\������
        //ShowCheckmark(clickedButton);

        //// ���O�ɃN���b�N���ꂽButton���X�V
        //lastClickedImage = clickedButton.image;

        Debug.Log("Button " + iconName + " clicked!");
        icon = clickedButton.image;
        // �����ɃN���b�N���ꂽButton�ɑ΂��鏈����ǉ�����
    }

    //void ShowCheckmark(Button button)
    //{
    //    if (checkmark == null)
    //    {
    //        // �`�F�b�N�}�[�N���܂��쐬����Ă��Ȃ��ꍇ�͍쐬
    //        checkmark = new GameObject("Checkmark");
    //        checkmark.transform.SetParent(button.transform, false);

    //        // �`�F�b�N�}�[�N�̃C���[�W�R���|�[�l���g��ǉ�
    //        Image checkmarkImage = checkmark.AddComponent<Image>();
    //        checkmarkImage.sprite = Resources.Load<Sprite>("checkmark"); // �`�F�b�N�}�[�N�̉摜�͓K�؂ȉ摜�ɕύX���Ă�������
    //        checkmarkImage.rectTransform.sizeDelta = new Vector2(30, 30); // �`�F�b�N�}�[�N�̃T�C�Y��K�؂ȃT�C�Y�ɕύX���Ă�������
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
    //    // �}�E�X�J�[�\����Button��ɂ���Ƃ��̏���
    //    // �C���[�W��������������
    //    eventData.pointerEnter.transform.localScale = originalScale * 1.1f;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    // �}�E�X�J�[�\����Button�ォ�痣�ꂽ�Ƃ��̏���
    //    // �C���[�W�̃X�P�[�������ɖ߂�
    //    eventData.pointerEnter.transform.localScale = originalScale;
    //}
}
