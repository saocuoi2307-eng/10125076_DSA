# Buổi 01 – Tổng quan, Phân tích giải thuật và Đệ quy

**Họ tên:** Hoàng Quốc Thái Đoàn  
**MSV:** 10125076

## Bài đã làm

- **Chương 1: Tổng quan** (Mục 1.4.2):
  - Bài 1: Tìm số lớn nhất và nhỏ nhất trong mảng 1000 phần tử.
  - Bài 2: Bài toán FizzBuzz.
  - Bài 3: Đảo ngược chuỗi.
  - Bài 4: In mảng và sắp xếp tăng dần.
  - Bài 5: Tìm số Fibonacci thứ n.

- **Chương 2: Phân tích giải thuật** (Mục 2.5.2 - Trang 77–79):
  - Bài 1: Tháp Hà Nội – Phân tích hệ thức truy hồi.
  - Bài 2: Tìm kiếm nhị phân (Binary Search) bằng phương pháp lặp và đệ quy.
  - Bài 3: Kiểm tra số nguyên tố bằng giải thuật cơ bản, cải tiến và Miller-Rabin.
  - Bài 4: Tìm các số hoàn hảo nhỏ hơn N bằng hai phương pháp.
  - Bài 5: Tìm số Fibonacci bằng đệ quy, vòng lặp, đệ quy có nhớ và lũy thừa ma trận.
  - Bài 6: Sắp xếp dãy số thực bằng Bubble Sort, Selection Sort, Insertion Sort, Quick Sort và Merge Sort.

- **Chương 3: Đệ quy** (Mục 3.7.2 - Trang 100–101):
  - Bài 1: Tính tổng S(n) = 1 + 2 + ... + n.
  - Bài 2: Tính tổng bình phương S(n) = 1² + 2² + ... + n².
  - Bài 3: Tính tổng nghịch đảo S(n) = 1 + 1/2 + ... + 1/n.
  - Bài 4: Tính lũy thừa x^n.
  - Bài 5: Tìm ước số lẻ lớn nhất của n.
  - Bài 6: Tìm ước chung lớn nhất của hai số a và b.
  - Bài 7: Đếm số chữ số của số nguyên dương n.
  - Bài 8: Tính biểu thức căn lồng nhau.

## Cấu trúc chương trình

Chương trình được viết bằng ngôn ngữ C#, sử dụng phương pháp lập trình hướng thủ tục, chia từng bài thành các hàm riêng để thuận tiện theo dõi và kiểm tra.

- `MenuChuong1()`: Quản lý các bài tập chương 1.
- `MenuChuong2()`: Quản lý các bài tập chương 2.
- `MenuChuong3()`: Quản lý các bài tập chương 3.
- Các hàm xử lý được tách riêng theo từng thuật toán.
- Sử dụng `BigInteger` để xử lý các giá trị Fibonacci lớn.
- Sử dụng `Stopwatch` để đo thời gian thực nghiệm của các giải thuật.

## Cách chạy

Mở terminal tại thư mục chứa file dự án `.csproj` và chạy lệnh:

```bash
dotnet run
```

Hoặc chạy trực tiếp bằng Visual Studio:

1. Mở project trong Visual Studio.
2. Mở file `Program.cs`.
3. Nhấn `Ctrl + F5` để chạy chương trình.
4. Chọn chương và bài tập tương ứng trong menu.

## Kết quả chạy

### Chương 1 – Tổng quan

**Bài 1: Tìm số lớn nhất và nhỏ nhất**

```text
========== CHƯƠNG 1 - TỔNG QUAN ==========
Đã tạo mảng gồm 1000 số tự nhiên ngẫu nhiên từ 0 đến 10000.
Số lớn nhất: (Kết quả phụ thuộc dữ liệu ngẫu nhiên)
Số nhỏ nhất: (Kết quả phụ thuộc dữ liệu ngẫu nhiên)
```

**Bài 2: FizzBuzz**

```text
1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz,
11, Fizz, 13, 14, FizzBuzz, 16, 17, Fizz, 19, Buzz, ...
```

**Bài 3: Đảo ngược chuỗi**

```text
Nhập chuỗi: SinhVien
Chuỗi sau khi đảo ngược: neiVhniS
```

**Bài 4: Sắp xếp mảng tăng dần**

```text
Mảng ban đầu: (1000 phần tử ngẫu nhiên)

Mảng sau khi sắp xếp tăng dần:
Các phần tử được sắp xếp từ nhỏ đến lớn.
```

**Bài 5: Fibonacci**

```text
Nhập n: 10
F(10) = 55
```

### Chương 2 – Phân tích giải thuật

**Bài 1: Tháp Hà Nội**

```text
Nhập số đĩa: 3
Số bước tối thiểu: 7

Hệ thức truy hồi:
T(n) = 2T(n - 1) + 1
T(1) = 1

Kết quả:
T(n) = 2^n - 1

Độ phức tạp: O(2^n)
```

**Bài 2: Tìm kiếm nhị phân**

```text
Tìm kiếm nhị phân lặp:
T(n) = T(n / 2) + 1

Tìm kiếm nhị phân đệ quy:
T(n) = T(n / 2) + 1

Độ phức tạp thời gian: O(log n)
```

**Bài 3: Kiểm tra số nguyên tố**

```text
Nhập n: 97

Duyệt từ 2 đến n - 1:
Là số nguyên tố.

Duyệt đến căn bậc hai của n:
Là số nguyên tố.

Miller-Rabin:
Là số nguyên tố.

Độ phức tạp:
Cách 1: O(n)
Cách 2: O(√n)
Cách 3: O(k log³ n) phép toán bit.
```

**Bài 4: Tìm số hoàn hảo nhỏ hơn N**

```text
Nhập N: 1000

Các số hoàn hảo theo cách cơ bản:
6 28 496

Các số hoàn hảo theo cách cải tiến:
6 28 496

Độ phức tạp:
Cách 1: O(N²)
Cách 2: O(N√N)
```

**Bài 5: Tìm số Fibonacci thứ n**

```text
Nhập n: 35

Kết quả:
Đệ quy trực tiếp: 9227465
Vòng lặp: 9227465
Đệ quy có nhớ: 9227465
Lũy thừa ma trận: 9227465

Độ phức tạp:
Đệ quy trực tiếp: O(2^n)
Vòng lặp: O(n)
Đệ quy có nhớ: O(n)
Lũy thừa ma trận: O(log n)
```

**Bài 6: Sắp xếp dãy số thực**

```text
Các thuật toán được thực hiện:

1. Bubble Sort
2. Selection Sort
3. Insertion Sort
4. Quick Sort
5. Merge Sort

Tất cả các thuật toán đều sắp xếp dãy số theo thứ tự tăng dần.

Chương trình thực hiện đo thời gian và so sánh kết quả giữa các thuật toán.
```

### Chương 3 – Đệ quy

**Bài 1: Tính tổng các số tự nhiên**

```text
Nhập n: 5
S(5) = 15
```

**Bài 2: Tính tổng bình phương**

```text
Nhập n: 5
S(5) = 55
```

**Bài 3: Tính tổng nghịch đảo**

```text
Nhập n: 5
S(5) = 2.2833333333
```

**Bài 4: Tính lũy thừa**

```text
Nhập cơ số x: 2
Nhập số mũ n: 5

2^5 = 32
```

**Bài 5: Tìm ước số lẻ lớn nhất**

```text
Nhập số nguyên dương n: 100
Ước số lẻ lớn nhất của 100 là 25.
```

**Bài 6: Tìm ước chung lớn nhất**

```text
Nhập a: 48
Nhập b: 18

UCLN(48, 18) = 6
```

**Bài 7: Đếm số chữ số**

```text
Nhập số nguyên dương n: 12345
Số chữ số của 12345 là 5.
```

**Bài 8: Tính biểu thức căn lồng nhau**

```text
Nhập n: 5

S(5) = 1.7562384876
```

---
