using AppNotas.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace RinconDelSaber

{
    public class AppSettings
    {
        public static string ApiFirebase = "https://centronive-default-rtdb.firebaseio.com/";
        private static string KeyAplication = "AIzaSyBVyoodYMOL8TJ8CUzROGWBi5dlyG3RhFg";


        public static ResponseAuthentication oAuthentication { get; set; }
        private static string ApiUrlGoogleApis = "https://identitytoolkit.googleapis.com/v1/";

        public static string ApiAuthentication(string tipo)
        {
            if (tipo == "LOGIN")
                return ApiUrlGoogleApis + "accounts:signInWithPassword?key=" + KeyAplication;
            else if (tipo == "SIGNIN")
                return ApiUrlGoogleApis + "accounts:signUp?key=" + KeyAplication;
            else
                return "";
        }

    }
}
