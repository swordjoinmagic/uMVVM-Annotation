using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using uMVVM;

class Test5 : MonoBehaviour{

    public void Test() {
        Debug.Log("这是要被AOP拦截的方法");
    }

    private void Start() {
        Proxy.Instance
            .SetTarger(this)
            .SetMethod("Test")
            .SetArgs(null)
            .SetInvocationHandler(new TestInovacationHandler())
            .Invoke();
    }
}
