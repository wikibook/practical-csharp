using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 공백 페이지의 아이템 템플레이트에 관해서는 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 를 참조하기 바랍니다

namespace Section05 {
    /// <summary>
    /// 그 자체로 사용할 수 있는 공백 페이지 또는 프레임 안에서 이동할 수 있는 공백 페이지
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        // List 16-12
        private async void button_Click(object sender, RoutedEventArgs e) {
            var texts = await GetLinesAsync();
            textBlock.Text = texts[0];
        }

        private async Task<string[]> GetLinesAsync() {
            var picker = new FileOpenPicker {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            picker.FileTypeFilter.Add(".txt");
            StorageFile file = await picker.PickSingleFileAsync();
            var texts = await FileIO.ReadLinesAsync(file);
            return texts.ToArray();
        }

        // List 16-13
        private async void button2_Click(object sender, RoutedEventArgs e) {
            await WriteTexts("sample.txt");
        }

        private async Task WriteTexts(string filename) {
            var lines = new string[] {
                "동해물과 백두산이",
                "마르고 닳도록",
                "하느님이 보우하사",
                "우리나라 만세",
           };

            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteLinesAsync(file, lines);
        }

        // List 16-14
        private async void button3_Click(object sender, RoutedEventArgs e) {
            var lines = await ReadLines("sample.txt");
            textBlock.Text = String.Join("\n", lines);
        }

        private async Task<IEnumerable<string>> ReadLines(string filename) {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(filename);
            var lines = await FileIO.ReadLinesAsync(file);
            return lines;
        }

        // List 16-15
        private async void button4_Click(object sender, RoutedEventArgs e) {
            var lines = await ReadLinesFromInstallFile();
            textBlock.Text = String.Join("\n", lines);
        }

        private async Task<IEnumerable<string>> ReadLinesFromInstallFile() {
            StorageFolder installedFolder = Package.Current.InstalledLocation;
            StorageFolder dataFolder = await installedFolder.GetFolderAsync("AppData");
            StorageFile sampleFile = await dataFolder.GetFileAsync("sample.txt");
            var lines = await FileIO.ReadLinesAsync(sampleFile);
            return lines;
        }
    }
}
