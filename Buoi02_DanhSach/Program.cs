Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(">>> PHẦN 2: CHƯƠNG 4 - MẢNG VÀ DANH SÁCH LIÊN KẾT");
Console.WriteLine("------------------------------------------------------------");

Console.WriteLine("=== Bài 1: Nhập, hiển thị và chèn phần tử x vào vị trí k ===");
C4_Bai1();

Console.WriteLine("=== Bài 2: Quản lý danh sách nhân viên ===");
C4_Bai2();

Console.WriteLine("=== Bài 3: Các hàm xử lý ma trận vuông ===");
C4_Bai3();

Console.WriteLine("=== Bài 4: Danh sách liên kết đơn (đếm x, min dương, xóa x) ===");
C4_Bai4();

Console.WriteLine("=== Bài 5: Các bài toán trên danh sách liên kết đơn ===");
C4_Bai5();







static void C4_Bai1()
using System;
using System.Text;

namespace BaiTap1_CauTrucDuLieu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n;
            do
            {
                Console.Write("Nhập số lượng phần tử n (n > 0): ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử a[{i}]: ");
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nDanh sách vừa nhập:");
            HienThiMang(a);

            Console.Write("\n\nNhập giá trị x cần chèn: ");
            int x = int.Parse(Console.ReadLine());

            int k;
            do
            {
                Console.Write($"Nhập vị trí k cần chèn (từ 0 đến {a.Length}): ");
                k = int.Parse(Console.ReadLine());
            } while (k < 0 || k > a.Length);
            int[] tmp = new int[a.Length + 1];
            for (int i = 0; i <= k - 1; i++)
            {
                tmp[i] = a[i];
            }

            tmp[k] = x;

            for (int i = k; i <= a.Length - 1; i++)
            {
                tmp[i + 1] = a[i];
            }

            a = tmp;

            Console.WriteLine($"\nDanh sách sau khi chèn {x} vào vị trí {k}:");
            HienThiMang(a);

            Console.ReadKey();
        }

        static void HienThiMang(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
static void C4_Bai2()
using System;
using System.Text;

namespace BaiTap2_QuanLyNhanVien
{
    struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
    }

    class VD
    {
        static NhanVien[] DS;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            NhapDanhSach();

            Console.WriteLine("\n--- DANH SÁCH NHÂN VIÊN BAN ĐẦU ---");
            XuatDanhSach(DS);

            long tongThucLinh = TinhTongThucLinh();
            Console.WriteLine($"\n=> Câu a: Tổng thực lĩnh tháng của tất cả nhân viên: {tongThucLinh:N0} VNĐ");
            Console.WriteLine("\n=> Câu b: Danh sách nhân viên có mức lương cơ bản thấp nhất:");
            InLuongCBThapNhat();

            int soLuongThuongCao = DemNhanVienThuongCao();
            Console.WriteLine($"\n=> Câu c: Số lượng nhân viên có mức thưởng >= 1.200.000: {soLuongThuongCao}");
            Console.WriteLine("\n=> Câu d: Danh sách sau khi sắp xếp (Tăng theo Phòng ban, Giảm theo Mã NV):");
            SapXepDanhSach();
            XuatDanhSach(DS);
            Console.WriteLine("\n=> Câu e: Danh sách sau khi cập nhật tăng lương cơ bản lên 5%:");
            CapNhatTangLuong5PhanTram();
            XuatDanhSach(DS);

            Console.ReadKey();
        }

        static void NhapDanhSach()
        {
            Console.Write("Nhập số lượng nhân viên n: ");
            int n = int.Parse(Console.ReadLine());
            DS = new NhanVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin nhân viên thứ {i + 1}:");
                Console.Write(" - Mã nhân viên: ");
                DS[i].MaNV = Console.ReadLine();

                Console.Write(" - Họ và tên: ");
                DS[i].Hoten = Console.ReadLine();

                Console.Write(" - Năm sinh: ");
                DS[i].Namsinh = int.Parse(Console.ReadLine());

                Console.Write(" - Phòng ban: ");
                DS[i].Phongban = Console.ReadLine();

                Console.Write(" - Lương cơ bản: ");
                DS[i].LuongCB = int.Parse(Console.ReadLine());

                Console.Write(" - Thưởng: ");
                DS[i].Thuong = int.Parse(Console.ReadLine());
            }
        }

        static void InMotNhanVien(int i)
        {
            Console.WriteLine($"Mã: {DS[i].MaNV,-8} | Tên: {DS[i].Hoten,-20} | NS: {DS[i].Namsinh,-6} | PB: {DS[i].Phongban,-12} | Lương CB: {DS[i].LuongCB,-10} | Thưởng: {DS[i].Thuong,-10} | Thực lĩnh: {thuclinh(i)}");
        }

        static void XuatDanhSach(NhanVien[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                InMotNhanVien(i);
            }
        }

        static int thuclinh(int x)
        {
            return DS[x].LuongCB + DS[x].Thuong;
        }

        static long TinhTongThucLinh()
        {
            long tong = 0;
            for (int i = 0; i < DS.Length; i++)
            {
                tong += thuclinh(i);
            }
            return tong;
        }

        static void InLuongCBThapNhat()
        {
            int min = int.MaxValue;

            for (int i = 0; i < DS.Length; i++)
            {
                if (min > DS[i].LuongCB)
                {
                    min = DS[i].LuongCB;
                }
            }

            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].LuongCB == min)
                {
                    InMotNhanVien(i);
                }
            }
        }

        static int DemNhanVienThuongCao()
        {
            int dem = 0;
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].Thuong >= 1200000)
                {
                    dem++;
                }
            }
            return dem;
        }

        static void SapXepDanhSach()
        {
            for (int i = 0; i < DS.Length - 1; i++)
            {
                for (int j = i + 1; j < DS.Length; j++)
                {
                    int soSanhPB = string.Compare(DS[i].Phongban, DS[j].Phongban, StringComparison.OrdinalIgnoreCase);

                    if (soSanhPB > 0 || (soSanhPB == 0 && string.Compare(DS[i].MaNV, DS[j].MaNV, StringComparison.OrdinalIgnoreCase) < 0))
                    {
                        NhanVien temp = DS[i];
                        DS[i] = DS[j];
                        DS[j] = temp;
                    }
                }
            }
        }

        static void CapNhatTangLuong5PhanTram()
        {
            for (int i = 0; i < DS.Length; i++)
            {
                DS[i].LuongCB = (int)(DS[i].LuongCB * 1.05);
            }
        }
    }
}
static void C4_Bai3()
using System;
using System.Text;

namespace BaiTap3_MaTranVuong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            int n;
            do
            {
                Console.Write("Nhập cấp của ma trận vuông n (0 < n < 100): ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0 || n >= 100);

            int[,] a = new int[n, n];
            NhapMaTran(a, n);

            Console.WriteLine("\n--- MA TRẬN VỪA NHẬP ---");
            XuatMaTran(a, n);

            int tongTatCa = TinhTongMaTran(a, n);
            Console.WriteLine($"\n=> Câu a: Tổng tất cả các phần tử của ma trận: {tongTatCa}");

            int minDuong = TimDuongNhoNhat(a, n);
            if (minDuong == -1)
            {
                Console.WriteLine("=> Câu b: Ma trận không có phần tử dương nào.");
            }
            else
            {
                Console.WriteLine($"=> Câu b: Giá trị dương nhỏ nhất của ma trận: {minDuong}");
            }

            int tongCheoPhu = TinhTongCheoPhu(a, n);
            Console.WriteLine($"=> Câu c: Tổng các phần tử nằm trên đường chéo phụ: {tongCheoPhu}");

            bool laTangDan = KiemTraCheoChinhTangDan(a, n);
            if (laTangDan)
            {
                Console.WriteLine("=> Câu d: Các phần tử trên đường chéo chính TĂNG DẦN.");
            }
            else
            {
                Console.WriteLine("=> Câu d: Các phần tử trên đường chéo chính KHÔNG TĂNG DẦN.");
            }

            Console.ReadKey();
        }

        static void NhapMaTran(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Nhập phần tử a[{i},{j}]: ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void XuatMaTran(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{a[i, j],6}");
                }
                Console.WriteLine();
            }
        }

        static int TinhTongMaTran(int[,] a, int n)
        {
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    t += a[i, j];
                }
            }
            return t;
        }

        static int TimDuongNhoNhat(int[,] a, int n)
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] > 0 && a[i, j] < min)
                    {
                        min = a[i, j];
                    }
                }
            }

            return (min == int.MaxValue) ? -1 : min;
        }

        static int TinhTongCheoPhu(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == (n - 1) - i)
                    {
                        tong += a[i, j];
                    }
                }
            }
            return tong;
        }

        static bool KiemTraCheoChinhTangDan(int[,] a, int n)
        {
            int[] tg = new int[n];
            for (int i = 0; i < n; i++)
            {
                tg[i] = a[i, i];
            }

            for (int i = 0; i <= n - 2; i++)
            {
                for (int j = i + 1; j <= n - 1; j++)
                {
                    if (tg[i] >= tg[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
static void C4_Bai4()
using System;
using System.Text;

namespace BaiTap4_DanhSachLienKetDon
{
    class Node
    {
        public int Info;
        public Node pNext;

        public Node(int x)
        {
            Info = x;
            pNext = null;
        }
    }

    class Program
    {
        static Node pHead = null;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            NhapDanhSach();

            Console.WriteLine("\n--- DANH SÁCH LIÊN KẾT VỪA NHẬP ---");
            XuatDanhSach();

            Console.Write("\n\nNhập giá trị x cần đếm: ");
            int xDem = int.Parse(Console.ReadLine());
            int soLuong = DemPhanTuX(xDem);
            Console.WriteLine($"=> Câu a: Số lượng phần tử có giá trị bằng {xDem} là: {soLuong}");

            int minDuong = TimDuongNhoNhat();
            if (minDuong == -1)
            {
                Console.WriteLine("=> Câu b: Danh sách không có phần tử dương nào.");
            }
            else
            {
                Console.WriteLine($"=> Câu b: Phần tử dương nhỏ nhất trong danh sách là: {minDuong}");
            }

            Console.Write("\nNhập giá trị x cần xóa (lần xuất hiện đầu tiên): ");
            int xXoa = int.Parse(Console.ReadLine());
            bool daXoa = XoaPhanTuXDauTien(xXoa);

            if (daXoa)
            {
                Console.WriteLine($"=> Câu c: Đã xóa phần tử {xXoa} đầu tiên. Danh sách còn lại:");
                XuatDanhSach();
            }
            else
            {
                Console.WriteLine($"=> Câu c: Không tìm thấy phần tử {xXoa} trong danh sách để xóa.");
            }

            Console.ReadKey();
        }

        static void ThemCuoi(int giaTri)
        {
            Node newNode = new Node(giaTri);
            if (pHead == null)
            {
                pHead = newNode;
            }
            else
            {
                Node p = pHead;
                while (p.pNext != null)
                {
                    p = p.pNext;
                }
                p.pNext = newNode;
            }
        }

        static void NhapDanhSach()
        {
            Console.Write("Nhập số lượng phần tử n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int val;
                do
                {
                    Console.Write($"Nhập phần tử nguyên dương thứ {i + 1}: ");
                    val = int.Parse(Console.ReadLine());
                } while (val <= 0); 

                ThemCuoi(val);
            }
        }

        static void XuatDanhSach()
        {
            if (pHead == null)
            {
                Console.Write("Danh sách rỗng!");
                return;
            }

            Node p = pHead;
            while (p != null)
            {
                Console.Write(p.Info + " -> ");
                p = p.pNext;
            }
            Console.Write("NULL");
        }

        static int DemPhanTuX(int x)
        {
            int d = 0;
            Node p = pHead;
            while (p != null)
            {
                if (p.Info == x)
                {
                    d = d + 1;
                }
                p = p.pNext;
            }
            return d;
        }

        static int TimDuongNhoNhat()
        {
            int minduong = int.MaxValue;
            Node p = pHead;

            while (p != null)
            {
                if (p.Info > 0 && p.Info < minduong)
                {
                    minduong = p.Info;
                }
                p = p.pNext;
            }

            return (minduong == int.MaxValue) ? -1 : minduong;
        }

        static bool XoaPhanTuXDauTien(int x)
        {
            Node p = pHead;
            Node t = null; 
            while (p != null && p.Info != x)
            {
                t = p;
                p = p.pNext;
            }

            if (p == null)
            {
                return false;
            }

            if (p == pHead)
            {
                pHead = pHead.pNext;
            }
            else
            {
                t.pNext = p.pNext; 
            }

            return true;
        }
    }
}
static void C4_Bai5()
using System;
using System.Text;

namespace BaiTap5_DanhSachLienKetDon
{
    class Node
    {
        public int Info;
        public Node pNext;

        public Node(int x)
        {
            Info = x;
            pNext = null;
        }
    }

    class LinkedList
    {
        public Node pHead = null;
    }

    class Program
    {
        static LinkedList l = new LinkedList();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            NhapDanhSach();

            Console.WriteLine("\n--- DANH SÁCH LIÊN KẾT l VỪA NHẬP ---");
            XuatDanhSach();

            if (l.pHead == null)
            {
                Console.WriteLine("\nDanh sách rỗng, kết thúc chương trình.");
                Console.ReadKey();
                return;
            }

            int maxVal = TimPhanTuLonNhat();
            Console.WriteLine($"\n\n=> Câu a: Phần tử lớn nhất trong danh sách l là: {maxVal}");

            long tong = TinhTongDanhSach();
            Console.WriteLine($"=> Câu b: Tổng các phần tử của danh sách l là: {tong}");

            int soLuongSNT = DemSoNguyenTo();
            Console.WriteLine($"=> Câu c: Số lượng số nguyên tố trong danh sách l là: {soLuongSNT}");

            Console.WriteLine("=> Câu d:");
            DemAmDuongKhong();

            Console.Write("\nNhập giá trị x cần đếm: ");
            int x = int.Parse(Console.ReadLine());
            int soLuongX = DemPhanTuBangX(x);
            Console.WriteLine($"=> Câu e: Số lượng phần tử có giá trị bằng {x} là: {soLuongX}");

            int minDuong = TimDuongNhoNhat();
            if (minDuong == -1)
            {
                Console.WriteLine("=> Câu f: Danh sách không có phần tử dương nào.");
            }
            else
            {
                Console.WriteLine($"=> Câu f: Phần tử dương nhỏ nhất trong danh sách là: {minDuong}");
            }

            Console.ReadKey();
        }

        static void ThemCuoi(int giaTri)
        {
            Node newNode = new Node(giaTri);
            if (l.pHead == null)
            {
                l.pHead = newNode;
            }
            else
            {
                Node p = l.pHead;
                while (p.pNext != null)
                {
                    p = p.pNext;
                }
                p.pNext = newNode;
            }
        }

        static void NhapDanhSach()
        {
            Console.Write("Nhập số lượng phần tử n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập số nguyên thứ {i + 1}: ");
                int val = int.Parse(Console.ReadLine());
                ThemCuoi(val);
            }
        }

        static void XuatDanhSach()
        {
            if (l.pHead == null)
            {
                Console.Write("Danh sách rỗng!");
                return;
            }

            Node p = l.pHead;
            while (p != null)
            {
                Console.Write(p.Info + " -> ");
                p = p.pNext;
            }
            Console.Write("NULL");
        }

        static int TimPhanTuLonNhat()
        {
            int max = int.MinValue;
            Node p = l.pHead;
            while (p != null)
            {
                if (p.Info > max)
                {
                    max = p.Info;
                }
                p = p.pNext;
            }
            return max;
        }

        static long TinhTongDanhSach()
        {
            long t = 0;
            Node p = l.pHead;
            while (p != null)
            {
                t += p.Info;
                p = p.pNext;
            }
            return t;
        }

        static bool KTNT(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static int DemSoNguyenTo()
        {
            int dem = 0;
            Node p = l.pHead;
            while (p != null)
            {
                if (KTNT(p.Info))
                {
                    dem++;
                }
                p = p.pNext;
            }
            return dem;
        }

        static void DemAmDuongKhong()
        {
            int demAm = 0, demDuong = 0, demKhong = 0;
            Node p = l.pHead;

            while (p != null)
            {
                if (p.Info < 0)
                {
                    demAm++;
                }
                else if (p.Info > 0)
                {
                    demDuong++;
                }
                else
                {
                    demKhong++;
                }
                p = p.pNext;
            }

            Console.WriteLine($"   + Số lượng số âm: {demAm}");
            Console.WriteLine($"   + Số lượng số dương: {demDuong}");
            Console.WriteLine($"   + Số lượng số bằng 0: {demKhong}");
        }

        static int DemPhanTuBangX(int x)
        {
            int dem = 0;
            Node p = l.pHead;
            while (p != null)
            {
                if (p.Info == x)
                {
                    dem++;
                }
                p = p.pNext;
            }
            return dem;
        }

        static int TimDuongNhoNhat()
        {
            int minduong = int.MaxValue;
            Node p = l.pHead;

            while (p != null)
            {
                if (p.Info < minduong && p.Info > 0)
                {
                    minduong = p.Info;
                }
                p = p.pNext;
            }

            return (minduong == int.MaxValue) ? -1 : minduong;
        }
    }
}
