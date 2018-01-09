using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Section05
{
    ///<summary>
    /// 기본 Application 클래스를 보완하는 응용 프로그램 고유의 동작을 제공합니다.
    ///</summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// 단일 응용 프로그램 오브젝트를 초기화합니다. 이것은 작성한 코드의
        /// 첫 행이므로 main() 또는 WinMain()과 논리적으로 등가입니다.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// 응용 프로그램이 엔드 유저에 의해 정상적으로 동작될 때 호출됩니다. 다른 엔트리 포인트는
        /// 응용 프로그램이 특정 파일을 열기 위해 시작됐을 때 사용됩니다.
        /// </summary>
        /// <param name="e">프로그램 시작을 요구하고 프로세스에 관한 자세한 사항을 표시합니다.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // 창에 이미 내용이 표시돼 있는 경우에는 응용 프로그램을 다시 초기화하지 않고
            // 창이 유효화돼 있는지만을 확인하기 바랍니다
            if (rootFrame == null)
            {
                // 네비게이션 컨텍스트의 형태로 동작하는 프레임을 생성하고 첫 페이지로 이동합니다
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: 이전에 중단한 응용 프로그램에서 상태를 읽어들입니다
                }

                // 프레임을 현재의 창에 배치합니다
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // 네비게이션 스택이 복원되지 않을 경우에는 첫 페이지로 이동합니다.
                    // 이때 필요한 정보를 네비게이션 매개변수의 형태로 넘겨주고 새로운 페이지를
                    // 구성합니다
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // 현재의 창이 유효화돼 있는지 확인합니다
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// 특정 페이지로 이동하지 못했을 때 호출됩니다.
        /// </summary>
        /// <param name="sender">이동에 실패한 프레임</param>
        /// <param name="e">네비게이션 오류에 관한 자세한 내용</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        ///<summary>
        /// 응용 프로그램의 실행이 중단됐을 때 호출됩니다.
        /// 응용 프로그램이 끝나거나 메모리의 내용 그대로 재개되도
        /// 응용 프로그램의 상태가 저장됩니다.
        ///</summary>
        ///<paramname= sender > 중단 요구를 송신한 쪽</param>
        ///<paramname= e > 중단 요구에 관한 자세한 내용</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: 응용 프로그램의 상태를 저장하고 백그라운드의 동작이 있으면 정지합니다
            deferral.Complete();
        }
    }
}
