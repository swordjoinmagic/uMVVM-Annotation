using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVVMLerning;
using UnityEngine.UI;

/// <summary>
/// 主界面
/// </summary>
class MainView : UnityGuiView<MainViewModel> {
    public Button add;
    public Button remove;
    public RectTransform FaceMembers;

    // faceView的Prefab
    public GameObject faceView;

    private void Awake() {
        BindingContext = new MainViewModel();
        BindingContext.Initializtion();
    }

    protected override void OnBindingContextChanged(MainViewModel oldViewModel, MainViewModel newViewModel) {
        base.OnBindingContextChanged(oldViewModel, newViewModel);

        if (oldViewModel != null) {
            oldViewModel.faceModels.OnValueChanged -= OnMembersPropertyValueChanged;
            oldViewModel.faceModels.OnAdd -= OnAdd;
            oldViewModel.faceModels.OnRemove -= OnRemove;
        }

        if (newViewModel != null) {
            newViewModel.faceModels.OnValueChanged += OnMembersPropertyValueChanged;
            newViewModel.faceModels.OnAdd += OnAdd;
            newViewModel.faceModels.OnRemove += OnRemove;
        }

        add.onClick.AddListener(AddMember);
        remove.onClick.AddListener(RemoveMember);
    }

    private void OnMembersPropertyValueChanged(List<FaceModel> oldValue,List<FaceModel> newValue) {
        for (int i=0;i<newValue.Count;i++) {
            var member = newValue[i];
            var newGameObject = Instantiate(faceView);
            newGameObject.name = member.Name;

            // 获得子view
            var subView = newGameObject.GetComponent<FaceView>();

            subView.BindingContext = new FaceViewModel() { ParentViewModel = BindingContext };
            subView.BindingContext.Initialization(member);
            subView.Reveal();

            // 设置该view的位置
            newGameObject.transform.parent = FaceMembers;
            newGameObject.transform.localScale = Vector3.one;

        }
    }

    private void OnAdd(FaceModel instance) {
        var newGameObject = Instantiate(faceView);
        newGameObject.name = instance.Name;

        // 获取子view
        var subView = newGameObject.GetComponent<FaceView>();
        subView.BindingContext = new FaceViewModel() { ParentViewModel = BindingContext };
        subView.BindingContext.Initialization(instance);

        newGameObject.transform.parent = FaceMembers;
        newGameObject.transform.localScale = Vector3.one;

    }

    private void OnRemove(FaceModel instance) {
        Destroy(GameObject.Find(instance.Name));
    }

    public void AddMember() {
        BindingContext.AddMember();
    }

    public void RemoveMember() {
        BindingContext.RemoveMember();
    }
}
