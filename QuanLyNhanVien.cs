using System.Runtime.CompilerServices;
using System.Text;

namespace Bai2
{
    #region Class Nguoi
    class Nguoi
    {
        #region Các thuộc tính
        private string maDD;
        private string hoTen;


        public string MaDD { get; set; } = string.Empty;

        public string HoTen { get; set; } = string.Empty;
        #endregion

        #region Hàm khởi tạo
        public Nguoi()
        {
            maDD = "Không biết";
            hoTen = "Không biết";

        }

        public Nguoi(string maDD, string hoTen)
        {
            this.maDD = maDD;
            this.hoTen = hoTen;
        }


        #endregion

        #region Phương thức
        public virtual void Nhap()
        {
            Console.Write("Nhập mã định danh: ");
            maDD = Console.ReadLine() ?? "";
            Console.Write("Nhập họ và tên: ");
            hoTen = Console.ReadLine()??"";
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Mã đinh danh: {maDD}");
            Console.WriteLine($"Họ tên: {hoTen}");
        }


        #endregion
    }
    #endregion


    #region Class NhanVien
    class NhanVien : Nguoi
    {
        #region Các thuộc tính
        private int namSinh;
        private float heSoLuong;
        private static double tienPhuCap = 500;


        public int NamSinh { get; set; }

        public float HeSoLuong { get; set; }
        #endregion


        #region Hàm khởi tạo
        public NhanVien() : base() { }

        public NhanVien(string maDD, string hoTen, int namSinh, float heSoLuong)
            : base(maDD, hoTen)
        {
            this.namSinh = namSinh;
            this.heSoLuong = heSoLuong;
        }
        #endregion


        #region Phương thức
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập năm sinh: ");
            namSinh = int.Parse(Console.ReadLine()??"");
            Console.Write("Hệ số lương: ");
            heSoLuong = float.Parse(Console.ReadLine()??"");
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Năm sinh: {namSinh}");
            Console.WriteLine($"Hệ số lương: {heSoLuong}");
            Console.WriteLine($"Lương: {tinhLuong()}");
        }

        public double tinhLuong()
        {
            return heSoLuong * 1550 + tienPhuCap;
        }

        public static bool operator > (NhanVien nv1, NhanVien nv2)
        {
            return nv1.heSoLuong > nv2.heSoLuong;
        }

        public static bool operator < (NhanVien nv1, NhanVien nv2)
        {
            return nv1.heSoLuong < nv2.heSoLuong;
        }
        #endregion
    }
    #endregion


    #region Class QuanLyNhanVien
    class QuanLyNhanVien
    {
        #region Các thuộc tính
        public List<NhanVien> nhanviens;
        #endregion


        #region Hàm khởi tạo
        public QuanLyNhanVien()
        {
            nhanviens = new List<NhanVien>();
        }
        #endregion


        #region Các phương thức
        public bool Them(NhanVien nv)
        {
            if (nhanviens.Contains(nv))
            {
                Console.WriteLine("Nhân viên đã có trong danh sách!");
                return false;
            }

            nhanviens.Add(nv);
            return true;
        }

        public bool CapNhatHoTen(string maDDCapNhat, string hoTenCapNhat)
        {
            for (int i = 0; i < nhanviens.Count; i++)
            {
                if (nhanviens[i].MaDD.Equals(maDDCapNhat)){
                    nhanviens[i].HoTen = hoTenCapNhat;
                    return true;
                }
            }
            return false;
        }

        public bool CapNhatNamSinh(string maDDCapNhat, int namSinhCapNhan)
        {
            for (int i = 0; i < nhanviens.Count; i++)
            {
                if (nhanviens[i].MaDD.Equals(maDDCapNhat)) // ???
                {
                    nhanviens[i].NamSinh = namSinhCapNhan;
                    return true;
                }
            }
            return false;
        }

        public bool CapNhatHeSoLuong(string maDDCapNhat, float heSoLuongCapNhat)
        {
            for (int i = 0; i < nhanviens.Count; i++)
            {
                if (nhanviens[i].MaDD.Equals(maDDCapNhat))
                {
                    nhanviens[i].HeSoLuong = heSoLuongCapNhat;
                    return true;
                }
            }
            return false;
        }

        public bool Xoa(string maDDXoa)
        {
            for (int i = 0; i < nhanviens.Count; i++)
            {
                if (nhanviens[i].MaDD.Equals(maDDXoa))
                {
                    nhanviens.Remove(nhanviens[i]);
                    return true;
                }   
            }
            return false;
        }

        public void HienThi()
        {
            if (nhanviens.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên rỗng!");
                return;
            }


            foreach (NhanVien nv in nhanviens){
                nv.Xuat();
                Console.WriteLine("-------------------------");
            }
        }
        #endregion


        #region Phương thức Main
        static void Main(string[] args)
        {
            // Cho phép sử dụng tiếng Việt.
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();


            bool dung = false;
            while (!dung)
            {
                Console.WriteLine("<===========>MENU<===========>");
                Console.WriteLine("1. Thêm nhân viên.");
                Console.WriteLine("2. Cập nhật cho nhân viên.");
                Console.WriteLine("3. Xóa nhân viên.");
                Console.WriteLine("4. Hiển thị danh sách nhân viên.");
                Console.WriteLine("0. Thoát.");
                Console.WriteLine("<===========>END<============>");
                Console.Write("Nhập lựa chọn của bạn: ");
                int luaChon = int.Parse(Console.ReadLine()??"");


                switch (luaChon)
                {
                    case 0:
                        dung = true;
                        break;
                    case 1:
                        // Tạo một nhân viên.
                        NhanVien nhanVienThem = new NhanVien();
                        nhanVienThem.Nhap();
                        if (quanLyNhanVien.Them(nhanVienThem))
                        {
                            Console.WriteLine("Thêm thành công!");
                        }
                        else
                        {
                            Console.WriteLine("Thêm thất bại!");
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("<=========>MENU Cập Nhật<=========>");
                            Console.WriteLine("1. Cập nhật họ tên nhân viên.");
                            Console.WriteLine("2. Cập nhật năm sinh nhân viên.");
                            Console.WriteLine("3. Cập nhật hệ số lương nhân viên.");
                            Console.WriteLine("0. Quay lại.");
                            Console.WriteLine("     <=========>END<=========>");
                            Console.Write("Nhập lựa chọn của bạn: ");
                            int luaChon1 = int.Parse(Console.ReadLine() ?? "");


                            string[] yes = { "y", "yes"};

                            if (luaChon1 == 0)
                            {
                                break;
                            }
                            else if (luaChon1 == 1)
                            {
                                while (true)
                                {
                                    Console.Write("Nhập mã định danh cập nhật: ");
                                    string maDDCapNhat = Console.ReadLine() ?? "";
                                    Console.Write("Nhập họ tên cập nhật: ");
                                    string hoTenCapNhat = Console.ReadLine() ?? "";
                                    if (quanLyNhanVien.CapNhatHoTen(maDDCapNhat, hoTenCapNhat))
                                    {
                                        Console.WriteLine("Cập nhật họ tên nhân viên thành công!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cập nhật họ tên nhân viên thất bại!");
                                    }

                                    Console.WriteLine("Bạn có muốn tiếp tục không? Nhập \"Yes\" or \"y\" để tiếp tục");
                                    string luaChon2 = Console.ReadLine()??"";
                                    luaChon2 = luaChon2.ToLower();
                                    if (!yes.Contains(luaChon2))
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (luaChon1 == 2)
                            {
                                while (true)
                                {
                                    Console.Write("Nhập mã định danh cập nhật: ");
                                    string maDDCapNhat = Console.ReadLine() ?? "";
                                    Console.Write("Nhập năm sinh cập nhật: ");
                                    int namSinhCapNhat = int.Parse(Console.ReadLine() ?? "");
                                    if (quanLyNhanVien.CapNhatNamSinh(maDDCapNhat, namSinhCapNhat))
                                    {
                                        Console.WriteLine("Cập nhật năm sinh nhân viên thành công!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cập nhật năm sinh nhân viên thất bại!");
                                    }

                                    Console.WriteLine("Bạn có muốn tiếp tục không? Nhập \"Yes\" or \"y\" để tiếp tục");
                                    string luaChon2 = Console.ReadLine() ?? "";
                                    luaChon2 = luaChon2.ToLower();
                                    if (!yes.Contains(luaChon2))
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (luaChon1 == 3)
                            {
                                while (true)
                                {
                                    Console.Write("Nhập mã định danh cập nhật: ");
                                    string maDDCapNhat = Console.ReadLine() ?? "";
                                    Console.Write("Nhập hệ số lương cập nhật: ");
                                    float heSoLuongCapNhat = float.Parse(Console.ReadLine() ?? "");
                                    if (quanLyNhanVien.CapNhatHeSoLuong(maDDCapNhat, heSoLuongCapNhat))
                                    {
                                        Console.WriteLine("Cập nhật hệ số lương nhân viên thành công!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cập nhật hệ số lương nhân viên thất bại!");
                                    }

                                    Console.WriteLine("Bạn có muốn tiếp tục không? Nhập \"Yes\" or \"y\" để tiếp tục");
                                    string luaChon2 = Console.ReadLine() ?? "";
                                    luaChon2 = luaChon2.ToLower();
                                    if (!yes.Contains(luaChon2))
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Lựa chọn không hợp lệ!, Cập nhật thất bại!");
                            }


                        }
                        break;
                    case 3:
                        Console.Write("Nhập mã định danh xóa: ");
                        String maDDXoa = Console.ReadLine()??"";
                        if (quanLyNhanVien.Xoa(maDDXoa))
                        {
                            Console.WriteLine("Xóa thành công!");
                        }
                        else
                        {
                            Console.WriteLine("Xóa thất bại!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Danh sách nhân viên: ");
                        Console.WriteLine("-----------------------------");
                        quanLyNhanVien.HienThi();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!, Vui lòng nhập lại!");
                        break;
                }
            }
        }
        #endregion
    }
    #endregion
}


