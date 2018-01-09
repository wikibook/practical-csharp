namespace SampleEntityFramework.Models {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BooksDbContext : DbContext {
        // 컨텍스트는 응용 프로그램의 구성 파일(App.config 또는 웹.config)로부터 'BooksDbContext'
        // 접속 문자열을 사용하도록 구성돼 있습니다. 기본 설정에서는 이 접속 문자열은 LocalDb 인스턴스 상의
        // 'SampleEntityFramework.Models.BooksDbContext' 데이터베이스를 대상으로 합니다.
        //
        // 다른 데이터베이스와 데이터베이스 프로바이더 또는 그 어떤 것을 대상으로 할 경우에는
        // 응용 프로그램의 구성 파일에서 'BooksDbContext' 접속 문자열을 수정하기바랍니다.
        public BooksDbContext()
            : base("name=BooksDbContext") {
        }

        // 모델에 포함할 수 있는 엔터티형마다 DbSet을 추가합니다. CodeFirst 모델의 구성 및 사용법의
        // 자세한 내용에 관해서는 http://go.microsoft.com/fwlink/?LinkId=390109를 참조하기 바랍니다.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}