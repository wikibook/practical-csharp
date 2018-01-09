using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 공백 페이지의 아이템 템플레이트에 관해서는 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 를 참조하기 바랍니다

namespace Section02Uwp
{
    /// <summary>
    /// 그 자체로 사용할 수 있는 공백 페이지 또는 프레임 안에서 이동할 수 있는 공백 페이지
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            PackageVersion();
        }

        // 코드14.8
        private void PackageVersion() {
            var version = Windows.ApplicationModel.Package.Current.Id.Version;
            textBlock.Text = string.Format("{0}.{1}.{2}.{3}",
                               version.Major, version.Minor, version.Build, version.Revision);
        }


    }
}
