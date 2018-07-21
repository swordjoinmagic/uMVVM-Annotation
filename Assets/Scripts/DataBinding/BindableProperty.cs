using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVMLerning {

    /// <summary>
    /// 可绑定属性，当该属性值发生改变时，
    /// 触发监听事件（也就是一个委托）
    /// </summary>
    /// <typeparam name="T">该可绑定属性的类型</typeparam>
    public class BindableProperty <T>{

        public delegate void OnValueChangeHandler(T oldValue,T newValue);

        T value;
        /// <summary>
        /// 触发的监听方法，由外部进行赋值
        /// </summary>
        public OnValueChangeHandler OnValueChange;

        public T Value {
            get {
                return value;
            }

            set {
                // 当值发生改变时，触发监听事件
                if (!object.Equals(this.value, value)) {
                    OnValueChange(this.value, value);
                    this.value = value;
                }
            }
        }

        public override string ToString() {
            if (this.value != null) {
                return "BindableProperty Value : " + this.value.ToString();
            } else {
                return "BindableProperty Value : null";
            }
        }
    }
}
