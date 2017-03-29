using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace participle.resoure
{
    // TODO: 将以下代码添加到 SomeType 的定义中，以便在调试 SomeType 的实例时可以看到这个可视化工具:
    // 
    //  [DebuggerVisualizer(typeof(Visualizer1))]
    //  [Serializable]
    //  public class SomeType
    //  {
    //   ...
    //  }
    // 
    /// <summary>
    /// 一个 SomeType 的可视化工具。 
    /// </summary>
    public class Visualizer1 : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (objectProvider == null)
                throw new ArgumentNullException("objectProvider");

            // TODO: 获取要为其显示可视化工具的对象。
            //       将 objectProvider.GetObject() 的结果的类型强制转换为
            //       要可视化的对象的类型。
            object data = (object)objectProvider.GetObject();

            // TODO: 显示您的对象视图。
            //       将 displayForm 替换为您自己的自定义窗体或控件。
            using (Form displayForm = new Form())
            {
                displayForm.Text = data.ToString();
                windowService.ShowDialog(displayForm);
            }
        }

        // TODO: 将下面的代码添加到您的测试代码中以测试可视化工具:
        // 
        //    Visualizer1.TestShowVisualizer(new SomeType());
        // 
        /// <summary>
        /// 将可视化工具承载于调试器之外，以此对该工具进行测试。
        /// </summary>
        /// <param name="objectToVisualize">要在可视化工具中显示的对象。</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(Visualizer1));
            visualizerHost.ShowVisualizer();
        }
    }
}
