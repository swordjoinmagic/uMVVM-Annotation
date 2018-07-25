using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMLerning;

public class MainViewModel : ViewModelBase{
    /// <summary>
    /// 数据源
    /// </summary>
    public List<FaceModel> DataSource = new List<FaceModel> {
        new FaceModel(){
            Name = "sjm",
            Level = 10,
            Face = "1231",
            Badge = new Badge{ Icon="adas",ElementColor="Red" }
        },
        new FaceModel(){
            Name = "znh",
            Level = 99,
            Face = "1231",
            Badge = new Badge{ Icon="adas",ElementColor="Green" }
        },
        new FaceModel(){
            Name = "sword_magic",
            Level = 299,
            Face = "1231",
            Badge = new Badge{ Icon="adas",ElementColor="Blue" }
        }
    }; 

    /// <summary>
    /// 该ViewModel的属性,一个动态数据集
    /// </summary>
    public readonly ObservableList<FaceModel> faceModels = new ObservableList<FaceModel>();

    public void Initializtion() {
        faceModels.Value = DataSource;
    }

    public void RemoveMember() {
        if (faceModels.Count > 0) {
            faceModels.Remove(faceModels[0]);
        }    
    }

    /// <summary>
    /// 随机给动态数据集增加数据
    /// </summary>
    public void AddMember() {
        if (faceModels.Count<3) {
            int n = new Random().Next(0, DataSource.Count - 1);
            var result = DataSource[n];
            faceModels.Add(result);
        }
    }
}
