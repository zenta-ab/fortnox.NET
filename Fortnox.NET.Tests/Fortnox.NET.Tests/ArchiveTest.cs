using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Archive;
using FortnoxNET.Models.Archive;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ArchiveTest : TestBase
    {
        [TestMethod]
        public async Task ItCanGetArchivedFilesAndFolders()
        {
            var request = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArchiveService.GetArchiveAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Folder);
        }

        [TestMethod]
        public async Task ItCanGetAFolderById()
        {
            var rootArchive = await GetArchives();

            if (!rootArchive.Folder.Folders.Any())
            {
                Assert.Inconclusive("Root archive contains no subfolders");
                return;
            }
            
            var request = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArchiveService.GetArchiveAsync(
                request,
                rootArchive.Folder.Folders.First().Id
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Folder);
        }

        [TestMethod]
        public async Task ItCanGetAFileById()
        {
            var rootArchive = await GetArchives();

            if (!rootArchive.Folder.Files.Any())
            {
                Assert.Inconclusive("Root archive contains no files");
                return;
            }
            
            var request = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArchiveService.GetFileAsync(
                request,
                rootArchive.Folder.Files.First().Id
            );
            
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task ItCanCreateAFolder()
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArchiveService.CreateFolderAsync(
                request, 
                $"Test{(new Random()).Next(0, 100000)}"
            );

            await RemoveFolder(response.Folder.Id);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Folder);
        }

        // [TestMethod]
        // public async Task ItCanCreateAFile()
        // {
        //     var tempFile = await CreateTempFile();
        //     var fileBytes = await File.ReadAllBytesAsync(tempFile);
        //     File.Delete(tempFile);
        //     
        //     var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
        //     var response = await ArchiveService.CreateFileAsync(request, fileBytes);
        //     
        //     Assert.IsNotNull(response);
        // }

        private async Task<Archive> GetArchives()
        {
            var request = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return await ArchiveService.GetArchiveAsync(request);
        }

        private async Task RemoveFolder(string folderId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArchiveService.DeleteArchiveAsync(request, folderId);
        }

        private async Task<string> CreateTempFile()
        {
            var tempFileName = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString()}.txt");

            using (var writer = new StreamWriter(tempFileName))
            {
                await writer.WriteLineAsync("Test");
            }

            return tempFileName;
        }
    }
}