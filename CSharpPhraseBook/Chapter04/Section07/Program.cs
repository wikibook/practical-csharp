using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0407 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 4")]
    class SampleCode {

        [ListNo("List 4-39")]
        //List 4-39
        public void sample01() {
            int count = 10;

            count++;
            ++count;

            Console.WriteLine(count);

        }

        [ListNo("List 4-40 / 41")]
        // List 4-40/ 41
        public void Sample02() {
            var path1 = @"C:\Example\Greeting.txt";
            var path2 = "C:\\Example\\Greeting.txt";

            Console.WriteLine(path1);
            Console.WriteLine(path2);

        }

        [ListNo("List 4-42")]
        // List 4-42
        public void Sample03() {
            var a = 10;
            var b = 20;
            Console.WriteLine("{0} {1}", a, b);

            var temp = a;
            a = b;
            b = temp;

            Console.WriteLine("{0} {1}", a, b);
        }

        [ListNo("List 4-43")]
        // List 4-43
        public void Sample04() {
            var str = "123";

            int height;
            if (int.TryParse(str, out height)) {
                // height에는 변환된 값이 들어 있다
                Console.WriteLine(height);
            } else {
                // 변환하지 못함
                Console.WriteLine("변환할 수 없습니다.");
            }


            //try {
            //    int retryCount = int.Parse(str);
            //    Console.WriteLine(retryCount);
            //} catch (ArgumentNullException ex) {
            //    Console.WriteLine("변환할 수 없습니다.");
            //} catch (FormatException ex) {
            //    Console.WriteLine("변환할 수 없습니다.");
            //}

        }

        [ListNo("List 4-44")]
        public void Sample05() {
            var Session = new Dictionary<string, object>();
            Session["MyProduct"] = null;

            var product = Session["MyProduct"] as Product;
            if (product == null) {
                // product를 가져오지 못했을 때의 처리
                Console.WriteLine("product를 가져올 수 없습니다.");
            } else {
                // product를 가져왔을 때의 처리
                Console.WriteLine("product를 가져왔습니다.");
            }

            // 아래는 비추천 코드
            //if (Session["MyProduct"] is Product) {
            //    var product = Session["MyProduct"] as Product;
            //    // product를 가져왔을 때의 처리
            //} else {
            //    // product를 가져오지 못했을 때의 처리
            //}

            //try {
            //    var product = (Product)Session["MyProduct"]; 
            //    // Product으로 캐스트했을 때의 처리
            //} catch (InvalidCastException e) {
            //    // Product형으로 캐스트하지 못했을 때의 처리
            //}
        }

        [ListNo("List 4-45")]
        public void Sample06() {
            try {
                var lines = File.ReadAllLines("sample.txt");

            } catch (FileNotFoundException ex) {
                // 예외 정보를 사용한 어떤 처리
                //……
                throw; 
            }

        }

        [ListNo("List 4-46")]
        public void Sample07() {
            var filePath = "sample.txt";
            using (var stream = new StreamReader(filePath)) { 
                var texts = stream.ReadToEnd();
                // 읽어들인 데이터를 여기서 처리한다
            }
        }

        [ListNo("List 4-47")]
        public void Sample08() {
            string filePath = "sample.txt";
            StreamReader stream = new StreamReader(filePath);
            try {
                string texts = stream.ReadToEnd();
                // 읽어들인 데이터를 여기서 처리한다
            }
            finally {
                stream.Dispose();  
            }
        }

        [ListNo("List 4-49")]
        public void Sample09() {
            var ver1 = new AppVersion(5, 3);
            Console.WriteLine(ver1);

            var ver2 = new AppVersion(5, 3, 9);
            Console.WriteLine(ver2);
        }
    }

    // List 4-48 / 49
    class AppVersion {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }

        //public AppVersion(int major, int minor)
        //  : this(major, minor, 0, 0) {  
        //}

        //public AppVersion(int major, int minor, int revision)
        //  : this(major, minor, revision, 0) {
        //}

        //public AppVersion(int major, int minor, int build, int revision) {
        //    Major = major;
        //    Minor = minor;
        //    Build = build;
        //    Revision = revision;
        //}


        // 주석 처리한 위의 세 개의 생성자는 아래에 나온 하나의 생성자 정의와 같다.

        public AppVersion(int major, int minor, int build = 0, int revision = 0) {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public override string ToString() {
            return $"{Major}.{Minor}.{Build}.{Revision}";
        }

    }

    internal class Product {

    }
}


