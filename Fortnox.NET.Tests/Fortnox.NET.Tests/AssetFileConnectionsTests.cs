using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.AssetFileConnections;
using FortnoxNET.Communication.Assets;
using FortnoxNET.Models.Assets;
using FortnoxNET.Models.FileConnections;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class AssetFileConnectionsTests : BaseFileConnectionTest
    {
        [TestMethod]
        public async Task ItCanGetAllAssetFileConnections()
        {
            var request = new AssetFileConnectionListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await AssetFileConnectionService.GetAssetFileConnectionsAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ItCanGetAssetConnectionsForAFile()
        {
            var connections = await GetConnections();

            if (connections == null || !connections.Any())
            {
                Assert.Inconclusive("No asset file connections exist in the system");
            }
            
            var request = new AssetFileConnectionListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await AssetFileConnectionService.GetAssetFileConnectionAsync(
                request,
                connections.First().FileId
            );
            
            Assert.IsNotNull(response);
            Assert.AreEqual(connections.First().FileId, response.FileId);
        }

        [TestMethod]
        public async Task ItCanCreateAConnectionBetweenAnAssetAndAFile()
        {
            var fileId = await CreateFile();
            var assets = await GetAssets();
            var asset = assets.FirstOrDefault() ?? await CreateAsset();
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);

            try
            {
                var response = await AssetFileConnectionService.CreateAssetFileConnection(
                    request,
                    asset.Id.ToString(),
                    fileId
                );

                await DeleteConnection(fileId);
                
                Assert.IsNotNull(response);
                Assert.AreEqual(fileId, response.FileId);
                Assert.AreEqual(asset.Id.ToString(), response.AssetId);
            }
            finally
            {
                await DeleteFile(fileId);

                if (!assets.Any())
                {
                    await DeleteAsset(asset.Id);
                }
            }
        }

        [TestMethod]
        public async Task ItCanDeleteAnConnectionBetweenAnAssetAndAFile()
        {
            var initialConnections = await GetConnections();
            var connection = await CreateConnection();

            try
            {
                var deleteRequest = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
                await AssetFileConnectionService.DeleteAssetFileConnection(deleteRequest, connection.FileId);
                
                var getConnectionRequest = new AssetFileConnectionListRequest(
                    connectionSettings.AccessToken, 
                    connectionSettings.ClientSecret
                );

                if (initialConnections.Count < 1)
                {
                    await Assert.ThrowsExceptionAsync<Exception>(async () =>
                    {
                        await AssetFileConnectionService.GetAssetFileConnectionAsync(
                            getConnectionRequest,
                            connection.FileId
                        );
                    });    
                }
                else
                {
                    var currentConnections = await GetConnections();
                    
                    Assert.AreEqual(initialConnections.Count, currentConnections.Count);
                }
                
            }
            finally
            {
                await DeleteFile(connection.FileId);
            }
        }

        private async Task<List<AssetFileConnections>> GetConnections()
        {
            var request = new AssetFileConnectionListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await AssetFileConnectionService.GetAssetFileConnectionsAsync(request)).Data.ToList();
        }

        private async Task<List<AssetSubset>> GetAssets()
        {
            var request = new AssetListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await AssetsService.GetAssetsAsync(request)).Data.ToList();
        }

        private async Task<AssetSubset> CreateAsset()
        {
            var currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var rand = new Random();
            var asset = new Asset()
            {
                Number = "TestProd" + rand.Next(9999999),
                Description = "TEST PRODUCT",
                TypeId = "8",
                DepreciationMethod = "0",
                AcquisitionValue = 13000,
                DepreciateToResidualValue = 1300,
                AcquisitionDate = currentDate.ToString("yyyy-MM-dd"),
                AcquisitionStart = currentDate.AddMonths(1).ToString("yyyy-MM-dd"),
                DepreciationFinal = currentDate.AddYears(1).ToString("yyyy-MM-dd"),
            };

            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await AssetsService.CreateAssetAsync(request, asset);
            
            return new AssetSubset()
            {
                Id = response.Id
            };
        }

        private async Task DeleteConnection(string fileId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await AssetFileConnectionService.DeleteAssetFileConnection(request, fileId);
        }

        private async Task DeleteAsset(int assetId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await AssetsService.DeleteAssetAsync(request, assetId.ToString());
        }

        private async Task<AssetFileConnection> CreateConnection()
        {
            var fileId = await CreateFile();
            var assets = await GetAssets();
            var asset = assets.FirstOrDefault() ?? await CreateAsset();
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            
            
            return await AssetFileConnectionService.CreateAssetFileConnection(
                request,
                asset.Id.ToString(),
                fileId
            );
        }
    }
}