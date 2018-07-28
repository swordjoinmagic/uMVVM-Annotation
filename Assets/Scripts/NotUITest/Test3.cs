using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.NotUITest {
    class Test3 : MonoBehaviour{

        IEnumerator Enumerator() {
            WWW wWW = new WWW("http://www.baidu.com");
            yield return wWW;
            Debug.Log(wWW.Current);
        }

        private void Awake() {
            
        }
    }
}
