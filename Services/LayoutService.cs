using PustokApp.Data;

namespace PustokApp.Services
{
    public class LayoutService
        (PustokDbContext pustokDb)
    {
        private readonly PustokDbContext _pustokDb = pustokDb;

        public List<Setting> GetStrings()
        {
            return _pustokDb.Settings.ToList();
        }
    }
}
