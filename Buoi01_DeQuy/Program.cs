using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Text;

internal class Program
{
    private static readonly Random random = new Random();

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("========== CHƯƠNG TRÌNH BÀI TẬP CẤU TRÚC GIẢI THUẬT ==========");
            Console.WriteLine("1. Chương 1 - Tổng quan");
            Console.WriteLine("2. Chương 2 - Phân tích giải thuật");
            Console.WriteLine("3. Chương 3 - Đệ quy");
            Console.WriteLine("0. Thoát chương trình");

            int chon = NhapSoNguyen("Chọn chương: ", 0, 3);

            switch (chon)
            {
                case 1:
                    MenuChuong1();
                    break;

                case 2:
                    MenuChuong2();
                    break;

                case 3:
                    MenuChuong3();
                    break;

                case 0:
                    Console.WriteLine("Đã thoát chương trình.");
                    return;
            }
        }
    }

    // ======================== CAC HAM NHAP DU LIEU ========================

    private static int NhapSoNguyen(string thongBao, int min, int max)
    {
        int giaTri;

        while (true)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine();

            if (int.TryParse(input, out giaTri) &&
                giaTri >= min && giaTri <= max)
                return giaTri;

            Console.WriteLine($"Vui lòng nhập số nguyên trong khoảng [{min}, {max}].");
        }
    }

    private static long NhapSoNguyenDuong(string thongBao)
    {
        long giaTri;

        while (true)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine();

            if (long.TryParse(input, out giaTri) && giaTri > 0)
                return giaTri;

            Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ.");
        }
    }

    private static double NhapSoThuc(string thongBao)
    {
        double giaTri;

        while (true)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine();

            bool hopLe = double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.CurrentCulture,
                out giaTri
            );

            if (!hopLe)
            {
                hopLe = double.TryParse(
                    input,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out giaTri
                );
            }

            if (hopLe && !double.IsNaN(giaTri) && !double.IsInfinity(giaTri))
                return giaTri;

            Console.WriteLine("Vui lòng nhập một số thực hợp lệ.");
        }
    }

    private static void DungManHinh()
    {
        Console.WriteLine();
        Console.Write("Nhấn Enter để tiếp tục...");
        Console.ReadLine();
    }

    private static void InMang<T>(T[] mang, int soPhanTuMoiDong = 20)
    {
        for (int i = 0; i < mang.Length; i++)
        {
            Console.Write($"{mang[i]}\t");

            if ((i + 1) % soPhanTuMoiDong == 0)
                Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static double DoThoiGian(Action thaoTac, int soLan = 1)
    {
        Stopwatch dongHo = Stopwatch.StartNew();

        for (int i = 0; i < soLan; i++)
            thaoTac();

        dongHo.Stop();

        return dongHo.Elapsed.TotalMilliseconds / soLan;
    }

    private static List<int> LayCacMocKichThuoc(int gioiHan, int[] cacMoc)
    {
        List<int> ketQua = new List<int>();

        foreach (int moc in cacMoc)
        {
            if (moc > 0 && moc <= gioiHan && !ketQua.Contains(moc))
                ketQua.Add(moc);
        }

        if (gioiHan >= 0 && !ketQua.Contains(gioiHan))
            ketQua.Add(gioiHan);

        ketQua.Sort();

        return ketQua;
    }

    // ================================================================
    //                    CHƯƠNG 1 - TỔNG QUAN
    // ================================================================

    private static void MenuChuong1()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("================ CHƯƠNG 1 - TỔNG QUAN ================");
            Console.WriteLine("1. Tìm số lớn nhất và nhỏ nhất trong mảng 1000 phần tử");
            Console.WriteLine("2. Bài toán FizzBuzz");
            Console.WriteLine("3. Đảo ngược chuỗi");
            Console.WriteLine("4. In và sắp xếp mảng 1000 phần tử");
            Console.WriteLine("5. Tìm số Fibonacci thứ n");
            Console.WriteLine("0. Quay lại menu chính");

            int chon = NhapSoNguyen("Chọn bài tập: ", 0, 5);

            if (chon == 0)
                return;

            Console.Clear();

            switch (chon)
            {
                case 1:
                    Bai1_Chuong1();
                    break;

                case 2:
                    Bai2_Chuong1();
                    break;

                case 3:
                    Bai3_Chuong1();
                    break;

                case 4:
                    Bai4_Chuong1();
                    break;

                case 5:
                    Bai5_Chuong1();
                    break;
            }

            DungManHinh();
        }
    }

    // Bài 1: Tìm số lớn nhất và nhỏ nhất trong mảng.

    private static void Bai1_Chuong1()
    {
        Console.WriteLine("BÀI 1: TÌM SỐ LỚN NHẤT VÀ NHỎ NHẤT TRONG MẢNG");

        int[] mang = new int[1000];

        for (int i = 0; i < mang.Length; i++)
            mang[i] = random.Next(0, 10001);

        int max = mang[0];
        int min = mang[0];

        for (int i = 1; i < mang.Length; i++)
        {
            if (mang[i] > max)
                max = mang[i];

            if (mang[i] < min)
                min = mang[i];
        }

        Console.WriteLine("Đã tạo mảng gồm 1000 số tự nhiên ngẫu nhiên từ 0 đến 10000.");
        Console.WriteLine("Số lớn nhất: " + max);
        Console.WriteLine("Số nhỏ nhất: " + min);
    }

    // Bài 2: FizzBuzz.

    private static void Bai2_Chuong1()
    {
        Console.WriteLine("BÀI 2: FIZZBUZZ");

        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                Console.Write("FizzBuzz");
            else if (i % 3 == 0)
                Console.Write("Fizz");
            else if (i % 5 == 0)
                Console.Write("Buzz");
            else
                Console.Write(i);

            if (i < 100)
                Console.Write(", ");

            if (i % 10 == 0)
                Console.WriteLine();
        }
    }

    // Bài 3: Đảo ngược chuỗi.

    private static void Bai3_Chuong1()
    {
        Console.WriteLine("BÀI 3: ĐẢO NGƯỢC CHUỖI");

        Console.Write("Nhập chuỗi: ");
        string chuoi = Console.ReadLine() ?? string.Empty;

        char[] kyTu = chuoi.ToCharArray();

        Array.Reverse(kyTu);

        Console.WriteLine("Chuỗi sau khi đảo ngược: " + new string(kyTu));
    }

    // Bài 4: In mảng và sắp xếp tăng dần.

    private static void Bai4_Chuong1()
    {
        Console.WriteLine("BÀI 4: IN VÀ SẮP XẾP MẢNG");

        int[] mang = new int[1000];

        for (int i = 0; i < mang.Length; i++)
            mang[i] = random.Next(0, 10001);

        Console.WriteLine("Mảng ban đầu:");
        InMang(mang);

        Array.Sort(mang);

        Console.WriteLine("Mảng sau khi sắp xếp tăng dần:");
        InMang(mang);
    }

    // Bài 5: Tìm số Fibonacci thứ n.

    private static void Bai5_Chuong1()
    {
        Console.WriteLine("BÀI 5: TÌM SỐ FIBONACCI THỨ n");

        int n = NhapSoNguyen("Nhập n (0 đến 10000): ", 0, 10000);

        Console.WriteLine($"F({n}) = {FibonacciLap(n)}");
    }

    // ================================================================
    //              CHƯƠNG 2 - PHÂN TÍCH GIẢI THUẬT
    // ================================================================

    private static void MenuChuong2()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("============= CHƯƠNG 2 - PHÂN TÍCH GIẢI THUẬT =============");
            Console.WriteLine("1. Tháp Hà Nội");
            Console.WriteLine("2. Tìm kiếm nhị phân (Binary Search)");
            Console.WriteLine("3. Kiểm tra số nguyên tố");
            Console.WriteLine("4. Liệt kê số hoàn hảo nhỏ hơn N");
            Console.WriteLine("5. Tìm số Fibonacci thứ n bằng nhiều giải thuật");
            Console.WriteLine("6. Sắp xếp dãy số thực bằng nhiều giải thuật");
            Console.WriteLine("0. Quay lại menu chính");

            int chon = NhapSoNguyen("Chọn bài tập: ", 0, 6);

            if (chon == 0)
                return;

            Console.Clear();

            switch (chon)
            {
                case 1:
                    Bai1_Chuong2();
                    break;

                case 2:
                    Bai2_Chuong2();
                    break;

                case 3:
                    Bai3_Chuong2();
                    break;

                case 4:
                    Bai4_Chuong2();
                    break;

                case 5:
                    Bai5_Chuong2();
                    break;

                case 6:
                    Bai6_Chuong2();
                    break;
            }

            DungManHinh();
        }
    }

    // Bài 1: Tháp Hà Nội.

    private static void Bai1_Chuong2()
    {
        Console.WriteLine("BÀI 1: THÁP HÀ NỘI");

        int n = NhapSoNguyen("Nhập số đĩa (1 đến 20): ", 1, 20);

        BigInteger soBuoc = BigInteger.Pow(2, n) - 1;

        Console.WriteLine("Số bước tối thiểu: " + soBuoc);
        Console.WriteLine("Hệ thức truy hồi: T(n) = 2T(n - 1) + 1, T(1) = 1.");
        Console.WriteLine("Thế liên tiếp: T(n) = 2^(n - 1)T(1) + 2^(n - 1) - 1.");
        Console.WriteLine("Với T(1) = 1, suy ra T(n) = 2^n - 1.");
        Console.WriteLine("Độ phức tạp: O(2^n), Ω(2^n), Θ(2^n).");

        if (n <= 10)
        {
            Console.WriteLine("\nCác bước di chuyển:");

            long dem = 0;

            ThapHaNoi(n, 'A', 'C', 'B', ref dem, true);
        }
        else
        {
            Console.WriteLine("Không in từng bước vì số bước di chuyển rất lớn.");
        }
    }

    private static void ThapHaNoi(
        int n,
        char cotNguon,
        char cotDich,
        char cotTrungGian,
        ref long dem,
        bool hienThi)
    {
        if (n == 1)
        {
            dem++;

            if (hienThi)
            {
                Console.WriteLine(
                    $"Bước {dem}: Chuyển đĩa 1 từ cột {cotNguon} sang cột {cotDich}."
                );
            }

            return;
        }

        ThapHaNoi(n - 1, cotNguon, cotTrungGian, cotDich, ref dem, hienThi);

        dem++;

        if (hienThi)
        {
            Console.WriteLine(
                $"Bước {dem}: Chuyển đĩa {n} từ cột {cotNguon} sang cột {cotDich}."
            );
        }

        ThapHaNoi(n - 1, cotTrungGian, cotDich, cotNguon, ref dem, hienThi);
    }

    // Bài 2: Tìm kiếm nhị phân.

    private static void Bai2_Chuong2()
    {
        Console.WriteLine("BÀI 2: TÌM KIẾM NHỊ PHÂN");

        int n = NhapSoNguyen(
            "Nhập số phần tử của mảng (1 đến 100000): ",
            1,
            100000
        );

        int[] mang = new int[n];

        for (int i = 0; i < n; i++)
        {
            mang[i] = NhapSoNguyen(
                $"mang[{i}] = ",
                int.MinValue,
                int.MaxValue
            );
        }

        Array.Sort(mang);

        Console.WriteLine("Mảng sau khi sắp xếp:");
        InMang(mang);

        int x = NhapSoNguyen(
            "Nhập giá trị cần tìm: ",
            int.MinValue,
            int.MaxValue
        );

        int viTriLap = TimKiemNhiPhanLap(mang, x);

        int viTriDeQuy = TimKiemNhiPhanDeQuy(
            mang,
            x,
            0,
            mang.Length - 1
        );

        Console.WriteLine("\nKết quả tìm kiếm:");

        Console.WriteLine(
            "Cách lặp: " +
            (viTriLap >= 0 ? $"Tìm thấy tại chỉ số {viTriLap}." : "Không tìm thấy.")
        );

        Console.WriteLine(
            "Cách đệ quy: " +
            (viTriDeQuy >= 0 ? $"Tìm thấy tại chỉ số {viTriDeQuy}." : "Không tìm thấy.")
        );

        int soLan = 10000;

        double tgLap = DoThoiGian(
            () => TimKiemNhiPhanLap(mang, x),
            soLan
        );

        double tgDeQuy = DoThoiGian(
            () => TimKiemNhiPhanDeQuy(mang, x, 0, mang.Length - 1),
            soLan
        );

        Console.WriteLine($"\nThời gian trung bình ({soLan:N0} lần chạy):");

        Console.WriteLine($"Tìm kiếm nhị phân lặp: {tgLap:F6} ms/lần.");

        Console.WriteLine($"Tìm kiếm nhị phân đệ quy: {tgDeQuy:F6} ms/lần.");

        Console.WriteLine("Hệ thức truy hồi: T(n) = T(n / 2) + 1, suy ra T(n) = Θ(log n).");

        Console.WriteLine(
            "Độ phức tạp thời gian: trường hợp tốt nhất Ω(1), " +
            "trung bình và xấu nhất Θ(log n), O(log n)."
        );

        Console.WriteLine(
            "Bộ nhớ phụ: cách lặp O(1); cách đệ quy O(log n) do ngăn xếp lời gọi hàm."
        );
    }

    private static int TimKiemNhiPhanLap(int[] mang, int x)
    {
        int left = 0;
        int right = mang.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (mang[mid] == x)
                return mid;

            if (mang[mid] < x)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    private static int TimKiemNhiPhanDeQuy(
        int[] mang,
        int x,
        int left,
        int right)
    {
        if (left > right)
            return -1;

        int mid = left + (right - left) / 2;

        if (mang[mid] == x)
            return mid;

        if (mang[mid] < x)
            return TimKiemNhiPhanDeQuy(mang, x, mid + 1, right);

        return TimKiemNhiPhanDeQuy(mang, x, left, mid - 1);
    }

    // Bài 3: Kiểm tra số nguyên tố.

    private static void Bai3_Chuong2()
    {
        Console.WriteLine("BÀI 3: KIỂM TRA SỐ NGUYÊN TỐ");

        int n = NhapSoNguyen(
            "Nhập số nguyên n (0 đến 10000000): ",
            0,
            10000000
        );

        bool cach1 = LaSoNguyenToCoBan(n);
        bool cach2 = LaSoNguyenToToiUu(n);
        bool cach3 = LaSoNguyenToMillerRabin(n);

        Console.WriteLine($"\nKết quả với n = {n}:");

        Console.WriteLine(
            "Duyệt từ 2 đến n - 1: " +
            (cach1 ? "Là số nguyên tố." : "Không phải số nguyên tố.")
        );

        Console.WriteLine(
            "Duyệt đến căn bậc hai của n: " +
            (cach2 ? "Là số nguyên tố." : "Không phải số nguyên tố.")
        );

        Console.WriteLine(
            "Miller-Rabin: " +
            (cach3 ? "Là số nguyên tố." : "Không phải số nguyên tố.")
        );

        double tg1 = DoThoiGian(() => LaSoNguyenToCoBan(n));
        double tg2 = DoThoiGian(() => LaSoNguyenToToiUu(n));
        double tg3 = DoThoiGian(() => LaSoNguyenToMillerRabin(n), 100);

        Console.WriteLine("\nThời gian với giá trị vừa nhập:");

        Console.WriteLine($"Giải thuật cơ bản: {tg1:F6} ms.");
        Console.WriteLine($"Giải thuật cải tiến: {tg2:F6} ms.");

        Console.WriteLine(
            $"Miller-Rabin (trung bình 100 lần): {tg3:F6} ms/lần."
        );

        Console.WriteLine("\nBảng so sánh theo kích thước n (dùng các số nguyên tố kiểm thử):");

        Console.WriteLine("n\t\tCơ bản (ms)\tCải tiến (ms)");

        int[] cacSoThu = { 101, 1009, 10007, 100003, 1000003 };

        foreach (int soThu in cacSoThu)
        {
            double thoiGianCoBan = DoThoiGian(
                () => LaSoNguyenToCoBan(soThu)
            );

            double thoiGianToiUu = DoThoiGian(
                () => LaSoNguyenToToiUu(soThu)
            );

            Console.WriteLine(
                $"{soThu}\t\t{thoiGianCoBan:F6}\t\t{thoiGianToiUu:F6}"
            );
        }

        Console.WriteLine("Cơ bản: O(n), Ω(1), trường hợp xấu nhất Θ(n).");

        Console.WriteLine("Cải tiến: O(√n), Ω(1), trường hợp xấu nhất Θ(√n).");

        Console.WriteLine(
            "Miller-Rabin: O(k log³ n) phép toán bit gần đúng, " +
            "với k là số cơ sở kiểm tra; bộ cơ sở này cho kết quả xác định " +
            "trên miền số nguyên 64-bit."
        );
    }

    private static bool LaSoNguyenToCoBan(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    private static bool LaSoNguyenToToiUu(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= n / i; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    private static bool LaSoNguyenToMillerRabin(long n)
    {
        if (n < 2)
            return false;

        int[] soNguyenToNho =
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37
        };

        foreach (int p in soNguyenToNho)
        {
            if (n == p)
                return true;

            if (n % p == 0)
                return false;
        }

        BigInteger d = n - 1;
        int s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s++;
        }

        long[] coSo =
        {
            2, 325, 9375, 28178, 450775, 9780504, 1795265022
        };

        BigInteger N = n;

        foreach (long giaTriCoSo in coSo)
        {
            BigInteger a = giaTriCoSo % N;

            if (a == 0)
                continue;

            BigInteger x = BigInteger.ModPow(a, d, N);

            if (x == 1 || x == N - 1)
                continue;

            bool vuotQua = true;

            for (int r = 1; r < s; r++)
            {
                x = (x * x) % N;

                if (x == N - 1)
                {
                    vuotQua = false;
                    break;
                }
            }

            if (vuotQua)
                return false;
        }

        return true;
    }

    // Bài 4: Liệt kê các số hoàn hảo nhỏ hơn N.

    private static void Bai4_Chuong2()
    {
        Console.WriteLine("BÀI 4: LIỆT KÊ SỐ HOÀN HẢO NHỎ HƠN N");

        int n = NhapSoNguyen("Nhập N (2 đến 5000): ", 2, 5000);

        List<int> ketQua1 = TimSoHoanHaoCoBan(n);

        List<int> ketQua2 = TimSoHoanHaoToiUu(n);

        Console.WriteLine("\nCác số hoàn hảo theo cách cơ bản:");
        InDanhSach(ketQua1);

        Console.WriteLine("Các số hoàn hảo theo cách cải tiến:");
        InDanhSach(ketQua2);

        Console.WriteLine("\nBảng thời gian theo kích thước N:");

        Console.WriteLine("N\t\tCơ bản (ms)\tCải tiến (ms)");

        List<int> cacMoc = LayCacMocKichThuoc(
            n,
            new int[] { 100, 500, 1000, 2000 }
        );

        foreach (int moc in cacMoc)
        {
            double tg1 = DoThoiGian(
                () => TimSoHoanHaoCoBan(moc)
            );

            double tg2 = DoThoiGian(
                () => TimSoHoanHaoToiUu(moc)
            );

            Console.WriteLine($"{moc}\t\t{tg1:F6}\t\t{tg2:F6}");
        }

        Console.WriteLine(
            "Cách cơ bản: O(N²), Ω(N²), Θ(N²) theo cách duyệt mọi ước."
        );

        Console.WriteLine(
            "Cách cải tiến: O(N√N), Ω(N√N), Θ(N√N) trong trường hợp tổng quát."
        );
    }

    private static List<int> TimSoHoanHaoCoBan(int n)
    {
        List<int> ketQua = new List<int>();

        for (int so = 2; so < n; so++)
        {
            int tong = 0;

            for (int uoc = 1; uoc < so; uoc++)
            {
                if (so % uoc == 0)
                    tong += uoc;
            }

            if (tong == so)
                ketQua.Add(so);
        }

        return ketQua;
    }

    private static List<int> TimSoHoanHaoToiUu(int n)
    {
        List<int> ketQua = new List<int>();

        for (int so = 2; so < n; so++)
        {
            int tong = 1;

            for (int uoc = 2; uoc <= so / uoc; uoc++)
            {
                if (so % uoc == 0)
                {
                    tong += uoc;

                    int uocDoi = so / uoc;

                    if (uocDoi != uoc)
                        tong += uocDoi;
                }
            }

            if (tong == so)
                ketQua.Add(so);
        }

        return ketQua;
    }

    private static void InDanhSach<T>(List<T> danhSach)
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Không có kết quả.");
            return;
        }

        foreach (T item in danhSach)
            Console.Write($"{item} ");

        Console.WriteLine();
    }

    // Bài 5: Tìm số Fibonacci bằng nhiều giải thuật.

    private static void Bai5_Chuong2()
    {
        Console.WriteLine("BÀI 5: TÌM SỐ FIBONACCI THỨ n");

        int n = NhapSoNguyen("Nhập n (0 đến 1000): ", 0, 1000);

        Console.WriteLine("\nKết quả:");

        if (n <= 35)
        {
            BigInteger deQuy = FibonacciDeQuy(n);

            Console.WriteLine("Đệ quy trực tiếp: " + deQuy);
        }
        else
        {
            Console.WriteLine(
                "Đệ quy trực tiếp: không chạy với n > 35 để tránh thời gian chờ quá lâu."
            );
        }

        BigInteger lap = FibonacciLap(n);

        BigInteger nho = FibonacciMemo(
            n,
            new BigInteger[n + 1],
            new bool[n + 1]
        );

        BigInteger maTran = FibonacciMaTran(n);

        Console.WriteLine("Dùng vòng lặp: " + lap);
        Console.WriteLine("Đệ quy có nhớ: " + nho);
        Console.WriteLine("Lũy thừa ma trận: " + maTran);

        Console.WriteLine("\nBảng thời gian theo kích thước n:");

        Console.WriteLine(
            "n\t\tĐệ quy trực tiếp\tVòng lặp\t\tĐệ quy nhớ\tMa trận"
        );

        List<int> cacMoc = LayCacMocKichThuoc(
            n,
            new int[] { 10, 20, 30, 35, 100, 300, 600 }
        );

        foreach (int moc in cacMoc)
        {
            string tgDeQuy = moc <= 35
                ? DoThoiGian(() => FibonacciDeQuy(moc)).ToString("F6")
                : "Không chạy";

            double tgLap = DoThoiGian(
                () => FibonacciLap(moc),
                10
            );

            double tgNho = DoThoiGian(
                () => FibonacciMemo(
                    moc,
                    new BigInteger[moc + 1],
                    new bool[moc + 1]
                ),
                10
            );

            double tgMaTran = DoThoiGian(
                () => FibonacciMaTran(moc),
                10
            );

            Console.WriteLine(
                $"{moc}\t\t{tgDeQuy}\t\t{tgLap:F6}\t\t{tgNho:F6}\t{tgMaTran:F6}"
            );
        }

        Console.WriteLine("\nĐộ phức tạp thời gian:");

        Console.WriteLine(
            "Đệ quy trực tiếp: O(2^n), Ω(1), Θ(φ^n) ở mức tăng trưởng thực tế."
        );

        Console.WriteLine("Vòng lặp: O(n), Ω(n), Θ(n).");

        Console.WriteLine("Đệ quy có nhớ: O(n), Ω(n), Θ(n).");

        Console.WriteLine(
            "Lũy thừa ma trận: O(log n), Ω(log n), Θ(log n) phép nhân ma trận."
        );
    }

    private static BigInteger FibonacciDeQuy(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciDeQuy(n - 1) + FibonacciDeQuy(n - 2);
    }

    private static BigInteger FibonacciLap(int n)
    {
        if (n <= 1)
            return n;

        BigInteger truoc = 0;
        BigInteger hienTai = 1;

        for (int i = 2; i <= n; i++)
        {
            BigInteger tiepTheo = truoc + hienTai;

            truoc = hienTai;
            hienTai = tiepTheo;
        }

        return hienTai;
    }

    private static BigInteger FibonacciMemo(
        int n,
        BigInteger[] memo,
        bool[] daTinh)
    {
        if (n <= 1)
            return n;

        if (daTinh[n])
            return memo[n];

        memo[n] = FibonacciMemo(n - 1, memo, daTinh)
                + FibonacciMemo(n - 2, memo, daTinh);

        daTinh[n] = true;

        return memo[n];
    }

    private static BigInteger FibonacciMaTran(int n)
    {
        if (n == 0)
            return BigInteger.Zero;

        BigInteger[,] maTran =
        {
            { BigInteger.One, BigInteger.One },
            { BigInteger.One, BigInteger.Zero }
        };

        BigInteger[,] ketQua = LuyThuaMaTran(maTran, n - 1);

        return ketQua[0, 0];
    }

    private static BigInteger[,] LuyThuaMaTran(
        BigInteger[,] maTran,
        int soMu)
    {
        BigInteger[,] ketQua =
        {
            { BigInteger.One, BigInteger.Zero },
            { BigInteger.Zero, BigInteger.One }
        };

        BigInteger[,] coSo = (BigInteger[,])maTran.Clone();

        int mu = soMu;

        while (mu > 0)
        {
            if (mu % 2 == 1)
                ketQua = NhanMaTran(ketQua, coSo);

            coSo = NhanMaTran(coSo, coSo);

            mu /= 2;
        }

        return ketQua;
    }

    private static BigInteger[,] NhanMaTran(
        BigInteger[,] a,
        BigInteger[,] b)
    {
        BigInteger[,] c = new BigInteger[2, 2];

        c[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
        c[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];

        c[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
        c[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];

        return c;
    }

    // Bài 6: Sắp xếp dãy số thực bằng nhiều giải thuật.

    private static void Bai6_Chuong2()
    {
        Console.WriteLine("BÀI 6: SẮP XẾP DÃY SỐ THỰC TĂNG DẦN");

        int n = NhapSoNguyen(
            "Nhập số phần tử (1 đến 5000): ",
            1,
            5000
        );

        double[] mang = new double[n];

        for (int i = 0; i < n; i++)
            mang[i] = NhapSoThuc($"mang[{i}] = ");

        Console.WriteLine("\nMảng ban đầu:");
        InMang(mang);

        double[] bubble = (double[])mang.Clone();
        double[] selection = (double[])mang.Clone();
        double[] insertion = (double[])mang.Clone();
        double[] quick = (double[])mang.Clone();
        double[] merge = (double[])mang.Clone();

        BubbleSort(bubble);
        SelectionSort(selection);
        InsertionSort(insertion);
        QuickSort(quick, 0, quick.Length - 1);
        MergeSort(merge);

        Console.WriteLine("\nKết quả sắp xếp (Bubble Sort):");
        InMang(bubble);

        Console.WriteLine("Kiểm tra kết quả:");

        Console.WriteLine(
            "Selection Sort: " + (MangDaTang(selection) ? "Đúng" : "Sai")
        );

        Console.WriteLine(
            "Insertion Sort: " + (MangDaTang(insertion) ? "Đúng" : "Sai")
        );

        Console.WriteLine(
            "Quick Sort: " + (MangDaTang(quick) ? "Đúng" : "Sai")
        );

        Console.WriteLine(
            "Merge Sort: " + (MangDaTang(merge) ? "Đúng" : "Sai")
        );

        Console.WriteLine("\nBảng thời gian theo kích thước mảng:");

        Console.WriteLine(
            "n\t\tBubble\t\tSelection\tInsertion\tQuick\t\tMerge"
        );

        List<int> cacMoc = LayCacMocKichThuoc(
            n,
            new int[] { 100, 500, 1000, 2000 }
        );

        foreach (int moc in cacMoc)
        {
            double[] duLieu = new double[moc];

            for (int i = 0; i < moc; i++)
                duLieu[i] = random.NextDouble() * 10000;

            double tgBubble = DoThoiGian(() =>
            {
                double[] a = (double[])duLieu.Clone();
                BubbleSort(a);
            });

            double tgSelection = DoThoiGian(() =>
            {
                double[] a = (double[])duLieu.Clone();
                SelectionSort(a);
            });

            double tgInsertion = DoThoiGian(() =>
            {
                double[] a = (double[])duLieu.Clone();
                InsertionSort(a);
            });

            double tgQuick = DoThoiGian(() =>
            {
                double[] a = (double[])duLieu.Clone();
                QuickSort(a, 0, a.Length - 1);
            });

            double tgMerge = DoThoiGian(() =>
            {
                double[] a = (double[])duLieu.Clone();
                MergeSort(a);
            });

            Console.WriteLine(
                $"{moc}\t\t{tgBubble:F6}\t{tgSelection:F6}\t" +
                $"{tgInsertion:F6}\t{tgQuick:F6}\t{tgMerge:F6}"
            );
        }

        Console.WriteLine("\nĐộ phức tạp thời gian:");

        Console.WriteLine(
            "Bubble Sort: tốt nhất Ω(n), xấu nhất O(n²), trung bình Θ(n²) với phiên bản có cờ dừng sớm."
        );

        Console.WriteLine("Selection Sort: Ω(n²), O(n²), Θ(n²).");

        Console.WriteLine(
            "Insertion Sort: tốt nhất Ω(n), xấu nhất O(n²), trung bình Θ(n²)."
        );

        Console.WriteLine(
            "Quick Sort: trung bình Θ(n log n), trường hợp tốt O(n log n), xấu nhất O(n²)."
        );

        Console.WriteLine(
            "Merge Sort: Ω(n log n), O(n log n), Θ(n log n); bộ nhớ phụ O(n)."
        );
    }

    private static void BubbleSort(double[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            bool daDoiCho = false;

            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                if (a[j] > a[j + 1])
                {
                    double tam = a[j];

                    a[j] = a[j + 1];
                    a[j + 1] = tam;

                    daDoiCho = true;
                }
            }

            if (!daDoiCho)
                break;
        }
    }

    private static void SelectionSort(double[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            int viTriNhoNhat = i;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j] < a[viTriNhoNhat])
                    viTriNhoNhat = j;
            }

            if (viTriNhoNhat != i)
            {
                double tam = a[i];

                a[i] = a[viTriNhoNhat];
                a[viTriNhoNhat] = tam;
            }
        }
    }

    private static void InsertionSort(double[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            double giaTri = a[i];

            int j = i - 1;

            while (j >= 0 && a[j] > giaTri)
            {
                a[j + 1] = a[j];
                j--;
            }

            a[j + 1] = giaTri;
        }
    }

    private static void QuickSort(double[] a, int left, int right)
    {
        int i = left;
        int j = right;

        double pivot = a[left + (right - left) / 2];

        while (i <= j)
        {
            while (a[i] < pivot)
                i++;

            while (a[j] > pivot)
                j--;

            if (i <= j)
            {
                double tam = a[i];

                a[i] = a[j];
                a[j] = tam;

                i++;
                j--;
            }
        }

        if (left < j)
            QuickSort(a, left, j);

        if (i < right)
            QuickSort(a, i, right);
    }

    private static void MergeSort(double[] a)
    {
        if (a.Length <= 1)
            return;

        double[] tam = new double[a.Length];

        MergeSort(a, tam, 0, a.Length - 1);
    }

    private static void MergeSort(
        double[] a,
        double[] tam,
        int left,
        int right)
    {
        if (left >= right)
            return;

        int mid = left + (right - left) / 2;

        MergeSort(a, tam, left, mid);

        MergeSort(a, tam, mid + 1, right);

        Tron(a, tam, left, mid, right);
    }

    private static void Tron(
        double[] a,
        double[] tam,
        int left,
        int mid,
        int right)
    {
        int i = left;
        int j = mid + 1;
        int k = left;

        while (i <= mid && j <= right)
        {
            if (a[i] <= a[j])
                tam[k++] = a[i++];
            else
                tam[k++] = a[j++];
        }

        while (i <= mid)
            tam[k++] = a[i++];

        while (j <= right)
            tam[k++] = a[j++];

        for (int viTri = left; viTri <= right; viTri++)
            a[viTri] = tam[viTri];
    }

    private static bool MangDaTang(double[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i - 1] > a[i])
                return false;
        }

        return true;
    }

    // ================================================================
    //                       CHƯƠNG 3 - ĐỆ QUY
    // ================================================================

    private static void MenuChuong3()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("================ CHƯƠNG 3 - ĐỆ QUY ================");
            Console.WriteLine("1. Tính S(n) = 1 + 2 + ... + n");
            Console.WriteLine("2. Tính S(n) = 1² + 2² + ... + n²");
            Console.WriteLine("3. Tính S(n) = 1 + 1/2 + ... + 1/n");
            Console.WriteLine("4. Tính lũy thừa x^n");
            Console.WriteLine("5. Tìm ước số lẻ lớn nhất của n");
            Console.WriteLine("6. Tìm ước chung lớn nhất của a và b");
            Console.WriteLine("7. Đếm số chữ số của n");
            Console.WriteLine("8. Tính biểu thức căn lồng nhau");
            Console.WriteLine("0. Quay lại menu chính");

            int chon = NhapSoNguyen("Chọn bài tập: ", 0, 8);

            if (chon == 0)
                return;

            Console.Clear();

            switch (chon)
            {
                case 1:
                    Bai1_Chuong3();
                    break;

                case 2:
                    Bai2_Chuong3();
                    break;

                case 3:
                    Bai3_Chuong3();
                    break;

                case 4:
                    Bai4_Chuong3();
                    break;

                case 5:
                    Bai5_Chuong3();
                    break;

                case 6:
                    Bai6_Chuong3();
                    break;

                case 7:
                    Bai7_Chuong3();
                    break;

                case 8:
                    Bai8_Chuong3();
                    break;
            }

            DungManHinh();
        }
    }

    // Bài 1: S(n) = 1 + 2 + ... + n.

    private static void Bai1_Chuong3()
    {
        Console.WriteLine("BÀI 1: TÍNH TỔNG 1 + 2 + ... + n");

        int n = NhapSoNguyen("Nhập n (1 đến 5000): ", 1, 5000);

        Console.WriteLine($"S({n}) = {TongTuNhienDeQuy(n)}");

        Console.WriteLine("Trường hợp cơ sở: S(1) = 1.");

        Console.WriteLine("Công thức đệ quy: S(n) = S(n - 1) + n.");

        Console.WriteLine(
            "Độ phức tạp thời gian: Θ(n); bộ nhớ ngăn xếp: O(n)."
        );
    }

    private static BigInteger TongTuNhienDeQuy(int n)
    {
        if (n == 1)
            return 1;

        return TongTuNhienDeQuy(n - 1) + n;
    }

    // Bài 2: S(n) = 1² + 2² + ... + n².

    private static void Bai2_Chuong3()
    {
        Console.WriteLine("BÀI 2: TÍNH TỔNG BÌNH PHƯƠNG");

        int n = NhapSoNguyen("Nhập n (1 đến 5000): ", 1, 5000);

        Console.WriteLine($"S({n}) = {TongBinhPhuongDeQuy(n)}");

        Console.WriteLine("Trường hợp cơ sở: S(1) = 1.");

        Console.WriteLine("Công thức đệ quy: S(n) = S(n - 1) + n².");

        Console.WriteLine(
            "Độ phức tạp thời gian: Θ(n); bộ nhớ ngăn xếp: O(n)."
        );
    }

    private static BigInteger TongBinhPhuongDeQuy(int n)
    {
        if (n == 1)
            return 1;

        return TongBinhPhuongDeQuy(n - 1) + (BigInteger)n * n;
    }

    // Bài 3: S(n) = 1 + 1/2 + ... + 1/n.

    private static void Bai3_Chuong3()
    {
        Console.WriteLine("BÀI 3: TÍNH TỔNG NGHỊCH ĐẢO");

        int n = NhapSoNguyen("Nhập n (1 đến 5000): ", 1, 5000);

        Console.WriteLine($"S({n}) = {TongNghichDaoDeQuy(n):F10}");

        Console.WriteLine("Trường hợp cơ sở: S(1) = 1.");

        Console.WriteLine("Công thức đệ quy: S(n) = S(n - 1) + 1/n.");

        Console.WriteLine(
            "Độ phức tạp thời gian: Θ(n); bộ nhớ ngăn xếp: O(n)."
        );
    }

    private static double TongNghichDaoDeQuy(int n)
    {
        if (n == 1)
            return 1.0;

        return TongNghichDaoDeQuy(n - 1) + 1.0 / n;
    }

    // Bài 4: Tính x^n.

    private static void Bai4_Chuong3()
    {
        Console.WriteLine("BÀI 4: TÍNH LŨY THỪA x^n");

        double x = NhapSoThuc("Nhập cơ số x: ");

        int n = NhapSoNguyen("Nhập số mũ n (0 đến 5000): ", 0, 5000);

        Console.WriteLine($"{x}^{n} = {LuyThuaDeQuy(x, n):G15}");

        Console.WriteLine("Trường hợp cơ sở: x⁰ = 1.");

        Console.WriteLine("Công thức đệ quy: xⁿ = x × xⁿ⁻¹.");

        Console.WriteLine(
            "Độ phức tạp thời gian: Θ(n); bộ nhớ ngăn xếp: O(n)."
        );
    }

    private static double LuyThuaDeQuy(double x, int n)
    {
        if (n == 0)
            return 1.0;

        return x * LuyThuaDeQuy(x, n - 1);
    }

    // Bài 5: Tìm ước số lẻ lớn nhất của n.

    private static void Bai5_Chuong3()
    {
        Console.WriteLine("BÀI 5: TÌM ƯỚC SỐ LẺ LỚN NHẤT");

        long n = NhapSoNguyenDuong("Nhập số nguyên dương n: ");

        Console.WriteLine(
            $"Ước số lẻ lớn nhất của {n} là {UocLeLonNhatDeQuy(n)}."
        );

        Console.WriteLine("Trường hợp cơ sở: nếu n lẻ thì kết quả bằng n.");

        Console.WriteLine(
            "Trường hợp đệ quy: nếu n chẵn thì UocLeMax(n) = UocLeMax(n / 2)."
        );

        Console.WriteLine(
            "Độ phức tạp thời gian: O(log n), bộ nhớ ngăn xếp: O(log n)."
        );
    }

    private static long UocLeLonNhatDeQuy(long n)
    {
        if (n % 2 != 0)
            return n;

        return UocLeLonNhatDeQuy(n / 2);
    }

    // Bài 6: Tìm ước chung lớn nhất của hai số.

    private static void Bai6_Chuong3()
    {
        Console.WriteLine("BÀI 6: TÌM ƯỚC CHUNG LỚN NHẤT");

        long a = NhapSoNguyenDuong("Nhập a: ");

        long b = NhapSoNguyenDuong("Nhập b: ");

        Console.WriteLine($"UCLN({a}, {b}) = {UCLNDeQuy(a, b)}");

        Console.WriteLine(
            "Trường hợp cơ sở: nếu b = 0 thì UCLN(a, b) = a."
        );

        Console.WriteLine(
            "Công thức đệ quy: UCLN(a, b) = UCLN(b, a mod b)."
        );

        Console.WriteLine(
            "Độ phức tạp thời gian: O(log(min(a, b)))."
        );
    }

    private static long UCLNDeQuy(long a, long b)
    {
        if (b == 0)
            return a;

        return UCLNDeQuy(b, a % b);
    }

    // Bài 7: Đếm số chữ số của n.

    private static void Bai7_Chuong3()
    {
        Console.WriteLine("BÀI 7: ĐẾM SỐ CHỮ SỐ CỦA n");

        long n = NhapSoNguyenDuong("Nhập số nguyên dương n: ");

        Console.WriteLine(
            $"Số chữ số của {n} là {DemChuSoDeQuy(n)}."
        );

        Console.WriteLine("Trường hợp cơ sở: SoChuSo(0) = 0.");

        Console.WriteLine(
            "Công thức đệ quy: SoChuSo(n) = SoChuSo(n / 10) + 1 khi n > 0."
        );

        Console.WriteLine(
            "Độ phức tạp thời gian: Θ(log n); bộ nhớ ngăn xếp: O(log n)."
        );
    }

    private static int DemChuSoDeQuy(long n)
    {
        if (n == 0)
            return 0;

        return DemChuSoDeQuy(n / 10) + 1;
    }

    // Bài 8: Tính biểu thức căn lồng nhau.

    private static void Bai8_Chuong3()
    {
        Console.WriteLine("BÀI 8: TÍNH BIỂU THỨC CĂN LỒNG NHAU");

        int n = NhapSoNguyen("Nhập n (1 đến 1000): ", 1, 1000);

        double ketQua = CanLongNhau(1, n);

        Console.WriteLine($"S({n}) = {ketQua:F10}");

        Console.WriteLine(
            "Biểu thức: √(1 + √(2 + √(3 + ... + √n)))."
        );

        Console.WriteLine("Trường hợp cơ sở: tại i = n, trả về √n.");

        Console.WriteLine(
            "Công thức đệ quy: Can(i, n) = √(i + Can(i + 1, n))."
        );

        Console.WriteLine(
            "Độ phức tạp thời gian: Θ(n); bộ nhớ ngăn xếp: O(n)."
        );
    }

    private static double CanLongNhau(int i, int n)
    {
        if (i == n)
            return Math.Sqrt(n);

        return Math.Sqrt(i + CanLongNhau(i + 1, n));
    }
}
