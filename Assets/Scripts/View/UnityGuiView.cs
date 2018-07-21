using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MVVMLerning {

    /// <summary>
    /// 所有View视图类的基类,继承Unity3D的MonoBehaviour类
    /// 以及实现IView接口,得以绑定一个ViewModel属性
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    class UnityGuiView<T> : MonoBehaviour, IView<T> where T : ViewModelBase {

        /// <summary>
        /// 表示该view是否已初始化
        /// </summary>
        private bool _isInitialized;

        /// <summary>
        /// 该视图绑定的ViewModel
        /// </summary>
        public readonly BindableProperty<T> viewModelProperty = new BindableProperty<T>();

        //public readonly BindableProperty<T> viewModelProperty;

        protected readonly PropertyBinder<T> binder = new PropertyBinder<T>();

        /// <summary>
        /// 实现接口,将该视图跟一个ViewModel绑定
        /// </summary>
        public T BindingContext {
            get {
                return viewModelProperty.Value;
            }
            set {

                // 如果该view还没有进行初始化, 那么进行一次初始化
                if (!_isInitialized) {
                    OnInitialize();
                    _isInitialized = true;
                }

                // 因为viewModelProperty是BinableProperty属性
                // 所以,在执行set方法时,会自动执行监听事件
                viewModelProperty.Value = value;
            }
        }

        /// <summary>
        /// 当本视图绑定的ViewModel改变时,执行的监听方法,
        /// 用virtual关键字修饰,主要是为了将来在子类中复写.
        /// 使用属性绑定器后:
        /// 无需在子类中编写成对的+=,-=方法,使用Unbind一键将
        /// 旧ViewModel中的所有委托去除,使用Bind方法将原先ViewModel中
        /// 的委托一个个加回到新ViewModel中
        /// </summary>
        /// <param name="oldViewModel"></param>
        /// <param name="newViewModel"></param>
        protected virtual void OnBindingContextChanged(T oldViewModel, T newViewModel) {
            binder.Unbind(oldViewModel);
            binder.Bind(newViewModel);
        }

        /// <summary>
        /// View的初始化方法,当BindContext(也就是这个View绑定的ViewModel)改变的时候执行.
        /// 只执行一次
        /// 
        /// 注: 在 @木宛城主 的代码中,OnInitialize方法的触发是在第一次为该View绑定的ViewModel
        /// 赋值的时候触发的,在这里注解一下,为什么不能将OnInitialize直接放在构造函数中,因为当
        /// 这个新的视图类被new出来的时候,其实他还没有绑定ViewModel,所以此时的ViewModel是Null,
        /// 如果此时触发OnInitialize方法,回应发空指针错误,所以将其放在第一次为该ViewModel赋值的时候
        /// 触发
        /// </summary>
        protected virtual void OnInitialize() {
            // 无论ViewModel的Value怎么变化,只对OnValueChanged事件监听一次
            viewModelProperty.OnValueChange += OnBindingContextChanged;
        }
    }
}
