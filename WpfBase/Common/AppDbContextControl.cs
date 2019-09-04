using System;
using WpfBase.Models;
using static WpfBase.Common.DB;

namespace WpfBase.Common
{
    public class AppDbContextControl
    {
        public static void ExecSaveChanges(Action action)
        {
            using (AppDbContext contexForSave = CreateAppDbContextForSave(true))
            {
                action();
                contexForSave.SaveChanges();
            }
        }
    }
}
