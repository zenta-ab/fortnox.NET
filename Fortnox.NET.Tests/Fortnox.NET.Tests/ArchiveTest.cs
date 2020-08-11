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

            await RemoveArchive(response.Folder.Id);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Folder);
        }

        [TestMethod]
        public async Task ItCanCreateAFile()
        {
            var tempFile = CreateTempFile(out var tempFileName);
            var fileBytes = await File.ReadAllBytesAsync(tempFile);
            File.Delete(tempFile);
            
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArchiveService.CreateFileAsync(request, fileBytes, tempFileName, "root");

            await RemoveArchive(response.Id);
            
            Assert.IsNotNull(response);
            Assert.AreEqual(tempFileName, response.Name);
        }

        [TestMethod]
        public async Task ItCanDeleteAFolder()
        {
            var createRequest = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var createdFolder = await ArchiveService.CreateFolderAsync(
                createRequest, 
                $"Test{(new Random()).Next(0, 100000)}"
            );

            var deleteRequest = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArchiveService.DeleteArchiveAsync(deleteRequest, createdFolder.Folder.Id);
            
            var getFolderRequest = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await ArchiveService.GetArchiveAsync(
                getFolderRequest,
                createdFolder.Folder.Id
            ));
        }

        [TestMethod]
        public async Task ItCanDeleteAFile()
        {
            var tempFile = CreateTempFile(out var tempFileName);
            var fileBytes = await File.ReadAllBytesAsync(tempFile);
            File.Delete(tempFile);
            
            var createRequest = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var createdFile = await ArchiveService.CreateFileAsync(createRequest, fileBytes, tempFileName, "root");
            
            var deleteRequest = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArchiveService.DeleteArchiveAsync(deleteRequest, createdFile.Id);
            
            var getFileRequest = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            
            await Assert.ThrowsExceptionAsync<Exception>(async () => await ArchiveService.GetFileAsync(
                getFileRequest,
                createdFile.Id
            ));
        }

        private async Task<Archive> GetArchives()
        {
            var request = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return await ArchiveService.GetArchiveAsync(request);
        }

        private async Task RemoveArchive(string archiveId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArchiveService.DeleteArchiveAsync(request, archiveId);
        }

        private string CreateTempFile(out string tempFileName)
        {
            tempFileName = $"{Guid.NewGuid().ToString()}.txt";
            var tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);

            using (var writer = new StreamWriter(tempFilePath))
            {
                writer.WriteLine("Test");
            }

            return tempFilePath;
        }
    }
}