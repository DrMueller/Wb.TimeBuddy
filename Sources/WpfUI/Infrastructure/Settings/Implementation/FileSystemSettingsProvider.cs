using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Models;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Settings.Implementation
{
    public class FileSystemSettingsProvider : IFileSystemSettingsProvider
    {
        public FileSystemSettings ProvideFileSystemSettings()
        {
            return new FileSystemSettings { DirectoryPath = @"C:\Users\mlm\Dropbox\Apps\WindowsBuddies\TimeBuddy\Data" };
        }
    }
}