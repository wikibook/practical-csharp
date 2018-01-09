# 1장 객체지향 프로그래밍 기초

C#으로 프로그램을 작성한다면 필연적으로 클래스를 정의하고 이용하게 됩니다. 이 책을 읽고 있는 독자는 이미 클래스에 관해 알고 있겠지만 아직 클래스에 충분히 익숙하지는 않을 수도 있습니다. 따라서 이 책의 제목인 'C# 프로그래밍의 관용구/정석 & 패턴'을 설명하기 전에 일단 클래스를 정의하고 이용할 때 반드시 이해하고 있어야 할 내용과 주의사항을 복습하겠습니다.
## 1-1:클래스

### 1-1-1:클래스를 정의한다

　'클래스'는 C#으로 프로그래밍할 때 가장 중요한 개념 중에 하나입니다. 클래스는 C#으로 객체지향 프로그래밍할 때 기초가 되는 것이므로 이 클래스를 제대로 이해해두는 것이 중요합니다.
일단은 클래스를 정의하는 방법에 관해 살펴보겠습니다.


    // 상품 클래스
	public class Product
	{
		// 상품 코드
		public int Code { get; set; }
		// 상품 이름
		public string Name { get; set; }
		// 상품 가격(세금이 붙지 않은 가격)
		public int Price { get; set; }
	}

위의 코드는 상품을 나타내는 Product 클래스를 정의한 예입니다. Product 클래스에는 Code, Name, Price 이렇게 세 개의 public 속성(공개 속성) 이 존재합니다. 이 Product 클래스에 두 개의 public 메서드를 추가해보겠습니다.

    public class Product {
       public int Code { get; set; }
       public string Name { get; set; }
       public int Price { get; set; }

       // 소비세를 구한다(소비세율은 8%)
       public int GetTax() {                       〈←추가한 메서드〉
          return (int)(Price * 0.08); 
       }
      
       // 세금을 포함한 가격을 구한다
       public int GetTaxIncludedPrice() {          〈←추가한 메서드〉
          return Price + GetTax();
       }
    }

　클래스에는 데이터 이외에 클래스가 어떤 동작을 하는지를 나타내는 메서드를 정의할 수 있다는 것을 알고 있을 것입니다. GetTax는 해당 상품의 소비세를 구하는 메서드이고 GetPriceIncludingTax는 해당 상품의 세금을 포함한 가격을 구하는 메서드입니다.
GetTax 메서드에서는 세금이 붙지 않은 가격에 소비세 8%를 곱해서 소비세를 구합니다. 이렇게 계산한 결과는 double형이 되므로 int형으로 캐스트(형변환)했습니다.
GetPriceIncludingTax 메서드에서는 1.08을 곱하는 것이 아니라 GetTax 메서드에서 구한 소비세를 Price에 더해서 세금을 포함한 가격을 구했습니다.
이제 Product 클래스에 생성자를 정의해보겠습니다(L 리스트1.1).


##### リスト1-1:Productクラス

    public class Product {
       public int Code { get; 【private】 set; }         〈←set을private로 수정〉
       public string Name { get; 【private】 set; }      〈←set을private로 수정〉
       public int Price { get; 【private】 set; }        〈←set을private로 수정〉

       // 생성자
       public 【Product】(int code, string name, int price) {  〈←추가한 생성자〉
          this.Code = code;
          this.Name = name;
          this.Price = price;
       }

       // 소비세를 구한다
       public int GetTax() {
          return (int)(Price * 0.08);
       }

       // 세금을 포함한 가격을 구한다
       public int GetTaxIncludedPrice() {
          return Price + GetTax();
       }
    }

생성자란 클래스와 이름이 같은 특수한 메서드입니다. 이 예에서는 상품 코드, 상품 이름, 상품 가격(세금을 뺀) 이렇게 세 개의 인수를 받는 생성자를 정의했습니다. 생성자의 정의에 맞춰 Code, Name, Price 속성에 있는 set 접근자의 권한을 private(비공개)로 변경했습니다. 이렇게 하면 Product 클래스를 이용하는 쪽이 생성자를 통하지 않고는 속성값을 설정할 수 없게 됩니다.
