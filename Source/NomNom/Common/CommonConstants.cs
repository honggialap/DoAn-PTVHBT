using NomNom.Models.KhuVucs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Common
{
    public static class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string CK_FINDER_PER = "CK_FINDER_PER";
        public static int THOI_GIAN_SHIP_MAX_MACDINH = 7;
        public static int THOI_GIAN_SHIP_MIN_MACDINH = 7;
        public static double PHI_SHIP_MACDINH = 10000;
        public static int TINH_TRANG_CHO_DUYET = 1;
        public static int TINH_TRANG_DA_DUYET = 2;
        public static int TINH_TRANG_DANG_GIAO = 3;
        public static int TINH_TRANG_HOAN_TAT = 4;
        public static int TINH_TRANG_DA_HUY = 5;
        public static int CHUC_VU_ADMIN = 1;
        public static int CHUC_VU_KHACH_HANG = 2;
        public static int DANG_KY_TAI_KHOAN_THANH_CONG = 1;
        public static int DANG_KY_TAI_KHOAN_THAT_BAI = 0;
        public static int DANG_KY_TAI_KHOAN_EMAIL_DA_TON_TAI = -1;
        public static int DANG_KY_TAI_KHOAN_TEN_TAI_KHOAN_DA_TON_TAI = -2;
        public static int DANG_KY_TAI_KHOAN_MAT_KHAU_DUOI_8 = -3;
        public static int DANG_NHAP_TAI_KHOAN_KHONG_TON_TAI = -1;
        public static int DANG_NHAP_MAT_KHAU_KHONG_DUNG = -2;
        public static int DANG_NHAP_TAI_KHOAN_BI_KHOA = -3;
        public static int DANG_NHAP_THAT_BAI = -4;
        public static int DANG_NHAP_THANH_CONG = 1;
        public static int DOI_MAT_KHAU_THAT_BAI = 0;
        public static int DOI_MAT_KHAU_MAT_KHAU_CU_KHONG_DUNG = -1;
        public static int DOI_MAT_KHAU_THANH_CONG = 1;
        public static int DOI_MAT_KHAU_MAT_KHAU_MOI_DUOI_8 = -2;
        public static int GIO_HANG_THEM_THANH_CONG = 1;
        public static int GIO_HANG_THEM_THAT_BAI = 0;
        public static int GIO_HANG_SAN_PHAM_DA_CO = -1;
        public static int SO_SAN_PHAM = 10; // số lượng sản phẩm mới nhất, bán chạy
        public static int SO_TIN_TUC = 5; //Số tin tức hiển thị trên trang chủ
    }
}