using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPhrase.TextFileProcessor.Framework;


/*

  마지막 연습문제에는 조금 어려운 함정이 있습니다.
  이 책에 나온 '17.2 TemplateMethod 패턴'에 나온 코드에서는 TextFileProcessor는 네임스페이스의 이름이었지만
  이 문제에서는 TextFileProcessor가 클래스 이름입니다.
  따라서 책에 나온 '코드17.8'을 참고로 해서 이 문제의 코드를 작성한다면 TextFileProcessor는
  클래스 이름과 네임스페이스 양쪽에 사용되는 이름이 돼버립니다.
  그러나 이 상태로는 문법 오류가 발생해서 빌드되지 않습니다.

  왜냐하면 C#에서는 네임스페이스을 닷(.)으로 구분한 이름과 클래스 이름이 같으면 단독 클래스 이름은 네임스페이스
  라고 간주하기 때문입니다.

  이렇게 되지 않게 하려면 오브젝트를 생성할 때 클래스 이름은 반드시 네임스페이스를 앞에 붙인 클래스 이름으로 지정
  해야 합니다. 다음의 코드가 해당 부분입니다.

     var processor = new Framework.TextFileProcessor(new ToHankakuService());

  그러나 일반적으로 이런 일이 발생하지 않을만한 네임스페이스 이름을지정하는 것이 일반적입니다.
  예를 들어 이 예에서는 네임스페이스를 CSharpPhrase.TextFileProcessor에서 CSharpPhrase.TextFileProsessing으로
  변경하는 방법으로 대처할 수 있을 것입니다.

  ...

  그러나 이 문제는 의존성의 주입(DI)이라는 패턴의 간단한 예입니다.
  TextFileProcessor 클래스는 ToHankakuService 클래스와 의존관계에 있는데 이 의존관계는
  다음과 같이 인스턴스를 생성했을 때 확립시키게 됩니다.

    new Framework.TextFileProcessor(new ToHankakuService());

  위의 코드는 수동으로 의존성을 주입하고 있는데 DI 컨테이너라고 불리는 것을 사용하면 코드 상에 직접 기술하지 않고도
  자동으로 의존성을 주입할 수 있습니다.
  .NET Framework에도 ManagedExtensibilityFramework라고 불리는 DI 컨테이너 기능을 가진 클래스 군이 제공돼 있습니다.
  그리고 외부의 DI 컨테이너로는 유니티(게임 엔진이 아닙니다),Spring.NET 등이 유명합니다.
  
*/


namespace CSharpPhrase.TextFileProcessor {
    class Program {
        static void Main(string[] args) {
            var processor = new Framework.TextFileProcessor(new ToHankakuService());
            processor.Run(args[0]);

            // 아래는 LineCounterService의 인스턴스를 넘겨주는 예입니다.
            //TextFileProcessor의 생성자에 ITextFileService를 구현한 클래스의 인스턴스를
            // 넘겨주면 TextFileProcessor 클래스는 다양한 동작이 가능하게 됩니다.

            //    var processor = new Framework.TextFileProcessor(new LineCounterService());
            //    processor.Run(args[0]);
        }
    }
}
