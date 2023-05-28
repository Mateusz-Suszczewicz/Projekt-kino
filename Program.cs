using kino;

namespace Projekt_kino
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
        public static Operator zalogowanyOperator = null;
        public static decimal cenaNormalna = 0;
        public static decimal cenaUlgowa = 0;
        public static kinoDB baza = new kinoDB(true);
    }
}